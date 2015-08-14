﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.ApplicationBlocks.Data;
using System.Collections;
using GRA.SRP.Core.Utilities;

namespace GRA.SRP.DAL
{

[Serializable]    public class MGMixAndMatchItems : EntityBase
    {

        #region Private Variables

        private static string conn = GRA.SRP.Core.Utilities.GlobalUtilities.SRPDB;

        private int myMMIID;
        private int myMMID;
        private int myMGID;
        private string myItemImage = "";
        private string myEasyLabel = "";
        private string myMediumLabel = "";
        private string myHardLabel = "";
        private string myAudioEasy = "";
        private string myAudioMedium = "";
        private string myAudioHard = "";
        private DateTime myLastModDate;
        private string myLastModUser = "N/A";
        private DateTime myAddedDate;
        private string myAddedUser = "N/A";

        #endregion

        #region Accessors

        public int MMIID
        {
            get { return myMMIID; }
            set { myMMIID = value; }
        }
        public int MMID
        {
            get { return myMMID; }
            set { myMMID = value; }
        }
        public int MGID
        {
            get { return myMGID; }
            set { myMGID = value; }
        }
        public string ItemImage
        {
            get { return myItemImage; }
            set { myItemImage = value; }
        }
        public string EasyLabel
        {
            get { return myEasyLabel; }
            set { myEasyLabel = value; }
        }
        public string MediumLabel
        {
            get { return myMediumLabel; }
            set { myMediumLabel = value; }
        }
        public string HardLabel
        {
            get { return myHardLabel; }
            set { myHardLabel = value; }
        }
        public string AudioEasy
        {
            get { return myAudioEasy; }
            set { myAudioEasy = value; }
        }
        public string AudioMedium
        {
            get { return myAudioMedium; }
            set { myAudioMedium = value; }
        }
        public string AudioHard
        {
            get { return myAudioHard; }
            set { myAudioHard = value; }
        }
        public DateTime LastModDate
        {
            get { return myLastModDate; }
            set { myLastModDate = value; }
        }
        public string LastModUser
        {
            get { return myLastModUser; }
            set { myLastModUser = value; }
        }
        public DateTime AddedDate
        {
            get { return myAddedDate; }
            set { myAddedDate = value; }
        }
        public string AddedUser
        {
            get { return myAddedUser; }
            set { myAddedUser = value; }
        }

        #endregion

        #region Constructors

        public MGMixAndMatchItems()
        {
        }

        #endregion

        #region stored procedure wrappers

        public static DataSet GetAll(int MGID)
        {
            SqlParameter[] arrParams = new SqlParameter[1];

            arrParams[0] = new SqlParameter("@MGID", MGID);

            return SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "app_MGMixAndMatchItems_GetAll", arrParams);
        }

        public static MGMixAndMatchItems FetchObject(int MMIID)
        {

            // declare reader

            SqlDataReader dr;

            SqlParameter[] arrParams = new SqlParameter[1];

            arrParams[0] = new SqlParameter("@MMIID", MMIID);

            dr = SqlHelper.ExecuteReader(conn, CommandType.StoredProcedure, "app_MGMixAndMatchItems_GetByID", arrParams);

            if (dr.Read())
            {

                // declare return value

                MGMixAndMatchItems result = new MGMixAndMatchItems();

                DateTime _datetime;

                int _int;

                //decimal _decimal;

                if (int.TryParse(dr["MMIID"].ToString(), out _int)) result.MMIID = _int;
                if (int.TryParse(dr["MMID"].ToString(), out _int)) result.MMID = _int;
                if (int.TryParse(dr["MGID"].ToString(), out _int)) result.MGID = _int;
                result.ItemImage = dr["ItemImage"].ToString();
                result.EasyLabel = dr["EasyLabel"].ToString();
                result.MediumLabel = dr["MediumLabel"].ToString();
                result.HardLabel = dr["HardLabel"].ToString();
                result.AudioEasy = dr["AudioEasy"].ToString();
                result.AudioMedium = dr["AudioMedium"].ToString();
                result.AudioHard = dr["AudioHard"].ToString();
                if (DateTime.TryParse(dr["LastModDate"].ToString(), out _datetime)) result.LastModDate = _datetime;
                result.LastModUser = dr["LastModUser"].ToString();
                if (DateTime.TryParse(dr["AddedDate"].ToString(), out _datetime)) result.AddedDate = _datetime;
                result.AddedUser = dr["AddedUser"].ToString();

                dr.Close();

                return result;

            }

            dr.Close();

            return null;

        }

        public bool Fetch(int MMIID)
        {

            // declare reader

            SqlDataReader dr;

            SqlParameter[] arrParams = new SqlParameter[1];

            arrParams[0] = new SqlParameter("@MMIID", MMIID);

            dr = SqlHelper.ExecuteReader(conn, CommandType.StoredProcedure, "app_MGMixAndMatchItems_GetByID", arrParams);

            if (dr.Read())
            {

                // declare return value

                MGMixAndMatchItems result = new MGMixAndMatchItems();

                DateTime _datetime;

                int _int;

                //decimal _decimal;

                if (int.TryParse(dr["MMIID"].ToString(), out _int)) this.MMIID = _int;
                if (int.TryParse(dr["MMID"].ToString(), out _int)) this.MMID = _int;
                if (int.TryParse(dr["MGID"].ToString(), out _int)) this.MGID = _int;
                this.ItemImage = dr["ItemImage"].ToString();
                this.EasyLabel = dr["EasyLabel"].ToString();
                this.MediumLabel = dr["MediumLabel"].ToString();
                this.HardLabel = dr["HardLabel"].ToString();
                this.AudioEasy = dr["AudioEasy"].ToString();
                this.AudioMedium = dr["AudioMedium"].ToString();
                this.AudioHard = dr["AudioHard"].ToString();
                if (DateTime.TryParse(dr["LastModDate"].ToString(), out _datetime)) this.LastModDate = _datetime;
                this.LastModUser = dr["LastModUser"].ToString();
                if (DateTime.TryParse(dr["AddedDate"].ToString(), out _datetime)) this.AddedDate = _datetime;
                this.AddedUser = dr["AddedUser"].ToString();

                dr.Close();

                return true;

            }

            dr.Close();

            return false;

        }

        public int Insert()
        {

            return Insert(this);

        }

        public static int Insert(MGMixAndMatchItems o)
        {

            SqlParameter[] arrParams = new SqlParameter[14];

            arrParams[0] = new SqlParameter("@MMID", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.MMID, o.MMID.GetTypeCode()));
            arrParams[1] = new SqlParameter("@MGID", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.MGID, o.MGID.GetTypeCode()));
            arrParams[2] = new SqlParameter("@ItemImage", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.ItemImage, o.ItemImage.GetTypeCode()));
            arrParams[3] = new SqlParameter("@EasyLabel", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.EasyLabel, o.EasyLabel.GetTypeCode()));
            arrParams[4] = new SqlParameter("@MediumLabel", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.MediumLabel, o.MediumLabel.GetTypeCode()));
            arrParams[5] = new SqlParameter("@HardLabel", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.HardLabel, o.HardLabel.GetTypeCode()));
            arrParams[6] = new SqlParameter("@AudioEasy", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.AudioEasy, o.AudioEasy.GetTypeCode()));
            arrParams[7] = new SqlParameter("@AudioMedium", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.AudioMedium, o.AudioMedium.GetTypeCode()));
            arrParams[8] = new SqlParameter("@AudioHard", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.AudioHard, o.AudioHard.GetTypeCode()));
            arrParams[9] = new SqlParameter("@LastModDate", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.LastModDate, o.LastModDate.GetTypeCode()));
            arrParams[10] = new SqlParameter("@LastModUser", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.LastModUser, o.LastModUser.GetTypeCode()));
            arrParams[11] = new SqlParameter("@AddedDate", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.AddedDate, o.AddedDate.GetTypeCode()));
            arrParams[12] = new SqlParameter("@AddedUser", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.AddedUser, o.AddedUser.GetTypeCode()));
            arrParams[13] = new SqlParameter("@MMIID", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.MMIID, o.MMIID.GetTypeCode()));
            arrParams[13].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "app_MGMixAndMatchItems_Insert", arrParams);

            o.MMIID = int.Parse(arrParams[13].Value.ToString());

            return o.MMIID;

        }

        public int Update()
        {

            return Update(this);

        }

        public static int Update(MGMixAndMatchItems o)
        {

            int iReturn = -1; //assume the worst

            SqlParameter[] arrParams = new SqlParameter[14];

            arrParams[0] = new SqlParameter("@MMIID", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.MMIID, o.MMIID.GetTypeCode()));
            arrParams[1] = new SqlParameter("@MMID", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.MMID, o.MMID.GetTypeCode()));
            arrParams[2] = new SqlParameter("@MGID", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.MGID, o.MGID.GetTypeCode()));
            arrParams[3] = new SqlParameter("@ItemImage", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.ItemImage, o.ItemImage.GetTypeCode()));
            arrParams[4] = new SqlParameter("@EasyLabel", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.EasyLabel, o.EasyLabel.GetTypeCode()));
            arrParams[5] = new SqlParameter("@MediumLabel", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.MediumLabel, o.MediumLabel.GetTypeCode()));
            arrParams[6] = new SqlParameter("@HardLabel", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.HardLabel, o.HardLabel.GetTypeCode()));
            arrParams[7] = new SqlParameter("@AudioEasy", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.AudioEasy, o.AudioEasy.GetTypeCode()));
            arrParams[8] = new SqlParameter("@AudioMedium", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.AudioMedium, o.AudioMedium.GetTypeCode()));
            arrParams[9] = new SqlParameter("@AudioHard", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.AudioHard, o.AudioHard.GetTypeCode()));
            arrParams[10] = new SqlParameter("@LastModDate", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.LastModDate, o.LastModDate.GetTypeCode()));
            arrParams[11] = new SqlParameter("@LastModUser", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.LastModUser, o.LastModUser.GetTypeCode()));
            arrParams[12] = new SqlParameter("@AddedDate", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.AddedDate, o.AddedDate.GetTypeCode()));
            arrParams[13] = new SqlParameter("@AddedUser", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.AddedUser, o.AddedUser.GetTypeCode()));

            try
            {

                iReturn = SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "app_MGMixAndMatchItems_Update", arrParams);

            }

            catch (SqlException exx)
            {

                System.Diagnostics.Debug.Write(exx.Message);

            }

            return iReturn;

        }

        public int Delete()
        {

            return Delete(this);

        }

        public static int Delete(MGMixAndMatchItems o)
        {

            int iReturn = -1; //assume the worst

            SqlParameter[] arrParams = new SqlParameter[1];

            arrParams[0] = new SqlParameter("@MMIID", GRA.SRP.Core.Utilities.GlobalUtilities.DBSafeValue(o.MMIID, o.MMIID.GetTypeCode()));

            try
            {

                iReturn = SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "app_MGMixAndMatchItems_Delete", arrParams);

            }

            catch (SqlException exx)
            {

                System.Diagnostics.Debug.Write(exx.Message);

            }

            return iReturn;

        }

        #endregion

    }//end class

}//end namespace

