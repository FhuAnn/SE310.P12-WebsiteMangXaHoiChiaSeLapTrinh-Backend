﻿using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories
{
    public interface IUserRepository : IStackOverflowRepository<User>
    {
        Task<User> Authenticate(string email,string password);

    }
}
