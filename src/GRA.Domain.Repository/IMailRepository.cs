﻿using GRA.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GRA.Domain.Repository
{
    public interface IMailRepository : IRepository<Mail>
    {
        Task<int> GetAllCountAsync(int siteId);
        Task<int> GetAdminUnreadCountAsync(int siteId);
        Task<IEnumerable<Mail>> PageAdminUnreadAsync(int siteId, int skip, int take);
        Task<int> GetUserCountAsync(int userId);
        Task<IEnumerable<Mail>> PageAllAsync(int siteId, int skip, int take);
        Task<IEnumerable<Mail>> PageUserAsync(int userId, int skip, int take);
        Task<int> GetUserUnreadCountAsync(int userId);
        Task MarkAsReadAsync(int mailId);
    }
}