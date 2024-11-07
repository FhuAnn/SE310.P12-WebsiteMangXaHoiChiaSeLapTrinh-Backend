using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment> GetByIdAsync(Guid id);
        Task<Comment> CreateAsync(Comment comment);
        Task<Comment> UpdateAsync(Guid id, Comment comment);
        Task<Comment> DeleteAsync(Guid id);
    }
}
