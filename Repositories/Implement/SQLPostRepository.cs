using Microsoft.EntityFrameworkCore;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement
{
    public class SQLPostRepository : StackOverflowRepository<Post>,IPostRepository
    {
        private readonly StackOverflowDBContext dbContext;

        public SQLPostRepository(StackOverflowDBContext dbContext):base(dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task<Post> GetPostDetailsAsync(Guid id)
        {
            var post = await dbContext.Posts
               .Include(p => p.User) // Bao gồm thông tin người dùng
               .Include(p => p.Answers) // Bao gồm các câu trả lời
               .Include(p => p.Comments) // Bao gồm các bình luận
               .Include(p => p.Posttags)
               .ThenInclude(pt => pt.Tag) // Bao gồm các thẻ
               .FirstOrDefaultAsync(p => p.Id == id); // Lọc theo ID bài viết

            return post;
        }
    }
}
