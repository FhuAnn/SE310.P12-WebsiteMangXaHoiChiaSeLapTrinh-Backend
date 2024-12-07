using Microsoft.EntityFrameworkCore;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using System.Xml.Linq;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement
{
    public class SQLCommentRepository : StackOverflowRepository<Comment>, ICommentRepository
    {
        private readonly Stackoverflow1511Context dbContext;

        public SQLCommentRepository(Stackoverflow1511Context dbContext) : base(dbContext)
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

        public async Task<IEnumerable<Comment>> GetCommentsByPostAsync(Guid postId)
        {
            return await dbContext.Comments
                .Where(c => c.PostId == postId)
                .Include(c => c.User)
                .OrderBy(c => c.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetCommentsByAnswerAsync(Guid answerId)
        {
            return await dbContext.Comments
                .Where(c => c.AnswerId == answerId)
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
