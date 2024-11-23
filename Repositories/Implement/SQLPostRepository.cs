using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using System.Formats.Asn1;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
               .Where(p => p.Id == id)
               .Select(p => new Post
               {
                   Id = p.Id,
                   Title = p.Title,
                   Tryandexpecting = p.Tryandexpecting,
                   Views = p.Views,
                   CreatedAt = p.CreatedAt,
                   UpdatedAt = p.UpdatedAt,
                   UserId = p.UserId,
                   Upvote = p.Upvote,
                   Downvote = p.Downvote,
                   Detailproblem = p.Detailproblem,
                   Answers = p.Answers.Select(ans=>new Answer
                   {
                       Id = ans.Id,
                       Body = ans.Body,
                       CreatedAt = ans.CreatedAt,
                       UpdatedAt = ans.UpdatedAt,
                       UserId = ans.UserId,
                       PostId = ans.PostId,
                       Upvote = ans.Upvote,
                       Downvote = ans.Downvote,
                       Comments = ans.Comments.Select(cmt=>new Comment
                       {
                           Id = cmt.Id,
                           Body =cmt.Body,
                           CreatedAt=cmt.CreatedAt,
                           UpdatedAt = cmt.UpdatedAt,
                           EntityType = cmt.EntityType,
                           EntityId = cmt.EntityId,
                       }).ToList()
                   }).ToList(),
                   Images = p.Images.Select(img=> new Image
                   {
                       id = img.id,
                       filePath = img.filePath,
                       postId = img.postId,
                   }).ToList(),
                   Posttags = p.Posttags.Select(pt=> new Posttag
                   {
                       TagId = pt.TagId,
                       Tag = new Tag { Tagname = pt.Tag.Tagname }
                   }).ToList(),
                   User= new User
                   {
                       Username = p.User.Username,
                       Gravatar = p.User.Gravatar
                   }
               }).SingleOrDefaultAsync();
             
            return post;
        }

        public async Task<List<Post>> GetPostHomesAsync()
        {
            /*var posts = await dbContext.Posts.Include(p => p.Posttags).Include(p=>p.User).Include(p=>p.Answers).ToListAsync();
            return posts;*/
            var posts = await dbContext.Posts
                .Select(p => new Post
                {
                    Id= p.Id,
                    Title= p.Title,
                    Tryandexpecting= p.Tryandexpecting,
                    Views= p.Views,
                    CreatedAt= p.CreatedAt,
                    UpdatedAt= p.UpdatedAt,
                    UserId= p.UserId,
                    Upvote= p.Upvote,
                    Downvote= p.Downvote,
                    Detailproblem= p.Detailproblem,
                    Answers = p.Answers,
                    User =p.User,
                    Posttags = p.Posttags.Select(pt=> new Posttag
                    {
                        TagId = pt.TagId,
                        Tag=pt.Tag
                    }).ToList()
                }).ToListAsync();

            return posts;
        }

        public async Task<Post> GetPostById(Guid postId)
        {
            return await dbContext.Posts.Include(p => p.Images).FirstOrDefaultAsync(p => p.Id == postId);
        }

        public async Task SavePost(Post post)
        {
            dbContext.Posts.Add(post);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Post>> GetByTagIdAsync(Guid tagId)
        {
            var posts = await dbContext.Posts
                .Where(p=>p.Posttags.Any(pt=>pt.TagId==tagId))
                .Select(p => new Post
                {
                    Id = p.Id,
                    Title = p.Title,
                    Tryandexpecting = p.Tryandexpecting,
                    Views = p.Views,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    UserId = p.UserId,
                    Upvote = p.Upvote,
                    Downvote = p.Downvote,
                    Detailproblem = p.Detailproblem,
                    Answers = p.Answers,
                    User = p.User,
                    Posttags = p.Posttags.Select(pt => new Posttag
                    {
                        PostId=pt.PostId,
                        TagId = pt.TagId,
                        Tag = pt.Tag
                    }).ToList()
                }).ToListAsync();

            return posts;
        }

        public async Task<Post> GetPostByPostIdAsync(Guid id)
        {
            var post = await dbContext.Posts
                .Where(p => p.Id==id)
                .Select(p => new Post
                {
                    Id = p.Id,
                    Title = p.Title,
                    Tryandexpecting = p.Tryandexpecting,
                    Views = p.Views,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    UserId = p.UserId,
                    Upvote = p.Upvote,
                    Downvote = p.Downvote,
                    Detailproblem = p.Detailproblem,
                    Answers = p.Answers,
                    User = p.User,
                    Posttags = p.Posttags.Select(pt => new Posttag
                    {
                        PostId = pt.PostId,
                        TagId = pt.TagId,
                        Tag = pt.Tag
                    }).ToList()
                }).SingleOrDefaultAsync();
            return post;
        }
    }
}
