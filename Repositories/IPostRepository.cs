using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories
{
    public interface IPostRepository:IStackOverflowRepository<Post>
    {
        Task<Post> GetPostDetailsAsync(Guid id);
        Task<List<Post>> GetPostHomesAsync();
        Task<Post> GetPostById(Guid postId);
        Task SavePost(Post post);
        Task<List<Post>> GetByTagIdAsync(Guid id);
        Task<List<Post>> GetPostByPostIdAsync(Guid id);

    }
}
