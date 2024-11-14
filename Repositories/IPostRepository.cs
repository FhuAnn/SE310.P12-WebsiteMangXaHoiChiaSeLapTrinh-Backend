using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories
{
    public interface IPostRepository:IStackOverflowRepository<Post>
    {
        Task<Post> GetPostDetailsAsync(Guid id);
        Task<List<Post>> GetPostHomesAsync();
        Task<Post> GetPostById(Guid postId);
        Task SavePost(Post post);
    }
}
