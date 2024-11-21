using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories
{
    public interface ICommentRepository : IStackOverflowRepository<Comment>
    {

        Task<Comment> AddCommentAsync(Comment comment);
        Task<Comment> GetCommentByIdAsync(Guid id);
        Task<IEnumerable<Comment>> GetCommentsByEntityAsync(Guid entityId, int entityType);
        Task<Comment> UpdateCommentAsync(Comment comment);
        Task<bool> DeleteCommentAsync(Guid commentId);

    }
}
