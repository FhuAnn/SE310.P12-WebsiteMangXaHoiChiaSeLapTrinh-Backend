using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NZWalk.API.Repositories;
using Org.BouncyCastle.Asn1;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using System.Formats.Asn1;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement
{
    public class SQLPostRepository : StackOverflowRepository<Post>,IPostRepository
    {
        private readonly Stackoverflow1511Context dbContext;
        private readonly IImageRepository imageRepository;

        public SQLPostRepository(Stackoverflow1511Context dbContext,IImageRepository imageRepository):base(dbContext) 
        {
            this.dbContext = dbContext;
            this.imageRepository = imageRepository;
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
                           PostId = cmt.PostId
                       }).ToList()
                   }).ToList(),
                   Images = p.Images.Select(img=> new Image
                   {
                       Id = img.Id,
                       FilePath = img.FilePath,
                       PostId = img.PostId,
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

        public async Task<List<Post>> GetByUserIdAsync(Guid id)
        {
            var posts = await dbContext.Posts
                .Where(p => p.UserId == id)
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
                    Comments=p.Comments.Select(cmt=>new Comment
                    {
                        Id=cmt.Id ,
                        Body= cmt.Body ,
                        CreatedAt= cmt.CreatedAt ,
                        UpdatedAt= cmt.UpdatedAt ,
                        UserId= cmt.UserId ,
                        User= cmt.User,
                    }).ToList(),
                    Posttags = p.Posttags.Select(pt => new Posttag
                    {
                        PostId = pt.PostId,
                        TagId = pt.TagId,
                        Tag = pt.Tag
                    }).ToList(),
                    ImageUrls = new List<string>()
                }).ToListAsync();
            foreach (var post in posts)
            {
                post.ImageUrls = await imageRepository.GetImageUrlsByPostId(post.Id);
            }
            return posts;
        }

        public async Task<List<Post>> GetMostAnsweredQuestionAsync()
        {
            var oneWeekAgo = DateTime.Now.AddDays(-7);
            var posts = await dbContext.Posts
                .Where(p=>p.Answers.Any(ans=>ans.CreatedAt>= oneWeekAgo))
                .OrderByDescending(p => p.Answers.Count(ans=>ans.CreatedAt>= oneWeekAgo))
                .Take(3)
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
                }).ToListAsync();
            return posts;
        }

        public async Task UpdatePostViewAsync(Post post)
        {
            // Tìm bài viết cần cập nhật
            var existingPost = await dbContext.Posts
                .FirstOrDefaultAsync(p => p.Id == post.Id);

            if (existingPost != null)
            {
                // Cập nhật thông tin bài viết, ví dụ: số lượt xem
                existingPost.Views = post.Views;

                // Đánh dấu bài viết là đã thay đổi
                dbContext.Posts.Update(existingPost);

                // Lưu thay đổi vào cơ sở dữ liệu
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<Post> DeletePostAsync(Guid postId)
        {
            var existingRecord = await dbContext.Posts.FirstOrDefaultAsync(post => post.Id == postId);
            if (existingRecord == null)
            {
                return null; // Nếu không tìm thấy bài viết, trả về null
            }

            // Xóa các bản ghi trong bảng posttag có post_id = postId
            var postTags = dbContext.Posttags.Where(pt => pt.PostId == postId);
            dbContext.Posttags.RemoveRange(postTags);

            var relatedAnswers = dbContext.Answers.Where(a => a.PostId == postId);
            dbContext.Answers.RemoveRange(relatedAnswers);

            // Xóa bài viết
            dbContext.Posts.Remove(existingRecord);

            // Lưu thay đổi vào cơ sở dữ liệu
            await dbContext.SaveChangesAsync();

            return existingRecord; // Trả về bài viết đã bị xóa
        }

        public async Task<List<Post>> SearchPostByKeyword(string keyword)
        {
            var posts = await dbContext.Posts
                 .Where(p =>
                           p.Title.Contains(keyword) ||
                           p.Tryandexpecting.Contains(keyword) ||
                            p.Detailproblem.Contains(keyword) ||
                            p.Posttags.Any(pt => pt.Tag.Tagname.Contains(keyword))) // Kiểm tra TagName trong Posttags
                             .OrderByDescending(p => p.CreatedAt) // Sắp xếp theo số câu trả lời
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
                            }).ToListAsync();
            return posts;
        }
    }
}
