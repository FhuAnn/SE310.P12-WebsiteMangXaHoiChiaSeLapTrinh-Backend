using Microsoft.EntityFrameworkCore;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using System.Xml.Linq;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement
{
    public class SQLCommentRepository : StackOverflowRepository<Comment>, ICommentRepository
    {
        private readonly StackOverflowDBContext dbContext;

        public SQLCommentRepository(StackOverflowDBContext dbContext) : base(dbContext)
        {
                this.dbContext = dbContext;
        }

        public async Task<Comment> AddCommentAsync(Comment comment)
        {
            dbContext.Comments.Add(comment);
            await dbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment> GetCommentByIdAsync(Guid id)
        {
            return await dbContext.Comments
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Comment>> GetCommentsByEntityAsync(Guid entityId, int entityType)
        {
            return await dbContext.Comments
                .Where(c => c.EntityId == entityId && c.EntityType == entityType)
                .Include(c => c.User)
                .OrderBy(c => c.CreatedAt)
                .ToListAsync();
        }

        // Triển khai phương thức sửa bình luận
        public async Task<Comment> UpdateCommentAsync(Comment comment)
        {
            dbContext.Comments.Update(comment);
            await dbContext.SaveChangesAsync();
            return comment;
        }

        // Triển khai phương thức xóa bình luận
        public async Task<bool> DeleteCommentAsync(Guid commentId)
        {
            var comment = await dbContext.Comments.FindAsync(commentId);
            if (comment == null) return false;

            dbContext.Comments.Remove(comment);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
