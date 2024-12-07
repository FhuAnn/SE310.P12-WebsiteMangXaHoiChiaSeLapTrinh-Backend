using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement
{
    public class SQLAnswerRepository : StackOverflowRepository<Answer>,IAnswerRepository
    {
        private readonly Stackoverflow1511Context dbContext;

        public SQLAnswerRepository(Stackoverflow1511Context dbContext):base(dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Answer>> GetAnswerByUserIdAsync(Guid id)
        {
            var answers = await dbContext.Answers
                .Where(x => x.UserId == id)
                .Select(ans => new Answer
                {
                    Id= ans.Id ,
                    Body= ans.Body ,
                    CreatedAt= ans.CreatedAt ,
                    UpdatedAt= ans.UpdatedAt ,
                    UserId= ans.UserId ,
                    PostId= ans.PostId ,
                    Upvote= ans.Upvote ,
                    Downvote= ans.Downvote ,
                    Post= new Post
                    {
                        Id= ans.Post.Id ,
                        Title= ans.Post.Title ,
                        Views = ans.Post.Views,
                        UserId=ans.UserId
                    },
                })
                .ToListAsync();
            return answers;
        }
    }
}
