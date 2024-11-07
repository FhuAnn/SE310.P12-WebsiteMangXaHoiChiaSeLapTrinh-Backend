using Microsoft.EntityFrameworkCore;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using System.Xml.Linq;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement
{
    public class SQLCommentRepository : ICommentRepository
    {
        private readonly StackOverflowDBContext dbContext;

        public SQLCommentRepository(StackOverflowDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Comment> CreateAsync(Comment comment)
        {
            await dbContext.Comments.AddAsync(comment);
            await dbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment> DeleteAsync(Guid id)
        {
            var existingComment = await dbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if (existingComment == null)
            {
                return null;
            }

            dbContext.Comments.Remove(existingComment);
            await dbContext.SaveChangesAsync();
            return existingComment;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await dbContext.Comments.ToListAsync();
        }

        public async Task<Comment> GetByIdAsync(Guid id)
        {
            return await dbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Comment> UpdateAsync(Guid id, Comment comment)
        {
            var existingComment = dbContext.Comments.FirstOrDefault(x => x.Id == id);
            if (existingComment == null)
            {
                return null;
            }

            //Only Change Body and UpdateAt
            existingComment.UpdatedAt = comment.UpdatedAt;
            existingComment.Body = comment.Body;

            await dbContext.SaveChangesAsync();
            return existingComment;
        }
    }
}
