using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories
{
    public interface IUserRoleRepository : IStackOverflowRepository<UserRole>
    {
        Task<ICollection<string>> GetUserRole(Guid userId);
    }
}
