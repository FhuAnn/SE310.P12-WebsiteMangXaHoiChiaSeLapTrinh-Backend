using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories
{
    public interface IUserRepository : IStackOverflowRepository<User>
    {
        Task<User> Authenticate(string email,string password);
        Task<List<User>> GetAllUserAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> GetUserByEmailAsync(string email);
        Task<bool> UpdatePassword(User user, string newPassword);
    }
}
