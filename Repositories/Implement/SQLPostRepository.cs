using Microsoft.EntityFrameworkCore;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement
{
    public class SQLPostRepository : IPostRepository
    {
        private readonly StackOverflowDBContext dbContext;

        public SQLPostRepository(StackOverflowDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Post> CreateAsync(Post post)
        {
            await dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();
            return post;
        }

        public async Task<Post> DeleteAsync(Guid id)
        {
            var existingPost = await dbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
            if (existingPost == null)
            {
                return null;
            }

            dbContext.Posts.Remove(existingPost);
            await dbContext.SaveChangesAsync();
            return existingPost;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await dbContext.Posts.ToListAsync();
        }

        public async Task<Post> GetByIdAsync(Guid id)
        {
            return await dbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Post> UpdateAsync(Guid id, Post post)
        {
            var existingPost = dbContext.Posts.FirstOrDefault(x => x.Id == id);
            if (existingPost == null)
            {
                return null;
            }

            //Only Change Body and UpdateAt
            existingPost.Title = post.Title;
            existingPost.Body = post.Body;
            existingPost.UpdatedAt = post.UpdatedAt;
            existingPost.Views  = post.Views;

            await dbContext.SaveChangesAsync();
            return existingPost;
        }
    }
}
