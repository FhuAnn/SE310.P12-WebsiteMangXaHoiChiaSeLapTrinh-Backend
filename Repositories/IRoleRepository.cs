using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllAsync();
        Task<Role> GetByIdAsync(Guid id);
        Task<Role> CreateAsync(Role answer);
        Task<Role> UpdateAsync(Guid id, Role answer);
        Task<Role> DeleteAsync(Guid id);
    }
}
