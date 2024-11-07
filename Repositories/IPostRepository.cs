using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAllAsync();
        Task<Post> GetByIdAsync(Guid id);
        Task<Post> CreateAsync(Post post);
        Task<Post> UpdateAsync(Guid id, Post post);
        Task<Post> DeleteAsync(Guid id);
    }
}
