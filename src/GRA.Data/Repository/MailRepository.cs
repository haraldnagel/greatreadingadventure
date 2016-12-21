﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GRA.Domain.Model;
using GRA.Domain.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper.QueryableExtensions;

namespace GRA.Data.Repository
{
    public class MailRepository
        : AuditingRepository<Model.Mail, Mail>, IMailRepository
    {
        public MailRepository(ServiceFacade.Repository repositoryFacade,
            ILogger<MailRepository> logger) : base(repositoryFacade, logger)
        {
        }

        public async Task<IEnumerable<Mail>> PageAllAsync(int siteId, int skip, int take)
        {
            return await DbSet
                .AsNoTracking()
                .Where(_ => _.IsDeleted == false
                       && _.SiteId == siteId)
                .OrderByDescending(_ => _.CreatedAt)
                .Skip(skip)
                .Take(take)
                .ProjectTo<Mail>()
                .ToListAsync();
        }

        public async Task<int> GetAllCountAsync(int siteId)
        {
            return await DbSet
                .AsNoTracking()
                .Where(_ => _.IsDeleted == false && _.SiteId == siteId)
                .CountAsync();
        }

        public async Task<int> GetAdminUnreadCountAsync(int siteId)
        {
            return await DbSet
                .AsNoTracking()
                .Where(_ => _.IsDeleted == false
                    && _.SiteId == siteId
                    && _.ToUserId == null
                    && _.IsNew == true)
                .CountAsync();
        }

        public async Task<IEnumerable<Mail>> PageAdminUnreadAsync(int siteId, int skip, int take)
        {
            return await DbSet
                .AsNoTracking()
                .Where(_ => _.IsDeleted == false
                    && _.SiteId == siteId
                    && _.ToUserId == null
                    && _.IsNew == true)
                .Skip(skip)
                .Take(take)
                .ProjectTo<Mail>()
                .ToListAsync();
        }

        public async Task<int> GetUserCountAsync(int userId)
        {
            return await DbSet
                .AsNoTracking()
                .Where(_ => _.IsDeleted == false
                    && (_.ToUserId == userId || _.FromUserId == userId))
                .CountAsync();
        }
        public async Task<IEnumerable<Mail>> PageUserAsync(int userId, int skip, int take)
        {
            return await DbSet
                .AsNoTracking()
                .Where(_ => _.IsDeleted == false
                    && (_.ToUserId == userId || _.FromUserId == userId))
                .Skip(skip)
                .Take(take)
                .ProjectTo<Mail>()
                .ToListAsync();
        }

        public async Task<int> GetUserUnreadCountAsync(int userId)
        {
            return await DbSet
                .AsNoTracking()
                .Where(_ => _.IsDeleted == false
                    && _.ToUserId == userId
                    && _.IsNew == true)
                .CountAsync();
        }

        public async Task MarkAsReadAsync(int mailId)
        {
            var mail = DbSet
                .Where(_ => _.Id == mailId)
                .SingleOrDefault();
            if (mail == null)
            {
                _logger.LogError($"Could not find mail id {mailId}");
                throw new Exception($"Could not find mail id {mailId}");
            }
            mail.IsNew = false;
            await SaveAsync();
        }

        public override async Task RemoveSaveAsync(int userId, int id)
        {
            var entity = await DbSet
                .Where(_ => _.IsDeleted == false && _.Id == id)
                .SingleAsync();
            entity.IsDeleted = true;
            await base.UpdateAsync(userId, entity, null);
            await base.SaveAsync();
        }
    }
}