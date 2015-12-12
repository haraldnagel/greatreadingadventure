﻿using Newtonsoft.Json;
using SRP_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace GRA.SRP.Handlers {
    public class JsonFeedEntry {
        public int ID { get; set; }
        public int AvatarId { get; set; }
        public string Username { get; set; }
        public string AwardedAt { get; set; }
        public int AwardReasonId { get; set; }
        public int BadgeId { get; set; }
        public int ChallengeId { get; set; }
        public string AchievementName { get; set; }

    }
    public class JsonFeed : JsonBase {
        public JsonFeedEntry[] Entries { get; set; }
        public int Latest { get; set; }
    }

    public class Feed : IHttpHandler, IRequiresSessionState {
        public void ProcessRequest(HttpContext context) {
            var jsonResponse = new JsonFeed();
            var entries = new List<JsonFeedEntry>();

            int after = 0;
            int.TryParse(context.Request.QueryString["after"], out after);

            //p.[AvatarID], p.[Username], bl.ListName, b.[UserName] as BadgeName, pp.[PPID], pp.[AwardDate], pp.[AwardReasonCd], pp.[BadgeId]
            try {
                var feed = new ActivityFeed().Latest(after);
                foreach(DataRow dataRow in feed.Rows) {
                    var entry = new JsonFeedEntry {
                        ID = (int)dataRow["PPID"],
                        AvatarId = (int)dataRow["AvatarID"],
                        Username = (string)dataRow["Username"],
                        AwardedAt = ((DateTime)dataRow["AwardDate"]).ToString(),
                        AwardReasonId = (int)dataRow["AwardReasonCd"],
                        BadgeId = (int)dataRow["BadgeId"],
                        ChallengeId = dataRow["BLID"] == DBNull.Value ? 0 : (int)dataRow["BLID"]
                    };

                    if(entry.ID > jsonResponse.Latest) {
                        jsonResponse.Latest = entry.ID;
                    }

                    switch(entry.AwardReasonId) {
                        case 1:
                            // got badge
                            entry.AchievementName = (string)dataRow["BadgeName"];
                            break;
                        case 2:
                            // completed challenge
                            entry.AchievementName = (string)dataRow["ListName"];
                            break;
                    }
                    entries.Add(entry);
                }

                jsonResponse.Entries = entries.ToArray();
                jsonResponse.Success = true;
            } catch (Exception ex) {
                this.Log().Error("Error loading feed: {0}", ex.Message);
                jsonResponse.Success = false;
            }
            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(jsonResponse));
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}