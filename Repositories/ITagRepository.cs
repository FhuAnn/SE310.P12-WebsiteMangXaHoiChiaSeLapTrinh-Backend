using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories
{
    public interface ITagRepository : IStackOverflowRepository<Tag>
    {
        Task<List<Tag>> SearchTagAsync(string searchTerm);
        Task<List<Tag>> GetTagsAsync();
        Task<bool> DeleteTagAsync(Guid id);


    }
}
