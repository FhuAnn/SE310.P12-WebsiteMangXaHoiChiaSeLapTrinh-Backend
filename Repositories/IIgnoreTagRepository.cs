using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories
{
    public interface IIgnoreTagRepository : IStackOverflowRepository<IgnoredTag>
    {
        Task<List<Tag>> GetIgnoredTagByUserIdAsync(Guid userId);

    }
}
