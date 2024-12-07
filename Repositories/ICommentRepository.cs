using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories
{
    public interface ICommentRepository : IStackOverflowRepository<Comment>
    {

        Task<Comment> AddCommentAsync(Comment comment);
        Task<Comment> GetCommentByIdAsync(Guid id);
        Task<Comment> UpdateCommentAsync(Comment comment);
        Task<bool> DeleteCommentAsync(Guid commentId);
        Task<IEnumerable<Comment>> GetCommentsByPostAsync(Guid postId);
        Task<IEnumerable<Comment>> GetCommentsByAnswerAsync(Guid answerId);

    }
}
