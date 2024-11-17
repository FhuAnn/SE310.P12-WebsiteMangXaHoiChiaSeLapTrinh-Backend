using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement
{
    public class SQLTagRepository : StackOverflowRepository<Tag>, ITagRepository
    {
        private readonly StackOverflowDBContext context;

        public SQLTagRepository(StackOverflowDBContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Tag>> GetTagsAsync()
        {
            var tags = await context.Tags
               .Select(p => new Tag
               {
                   Id = p.Id,
                   Tagname = p.Tagname,
                   Description = p.Description,
                   CreatedAt = p.CreatedAt,
                   UpdatedAt = p.UpdatedAt,

                   Posttags = p.Posttags.Select(pt => new Posttag
                   {
                       PostId = pt.PostId,
                       Post = pt.Post
                   }).ToList()
               }).ToListAsync();

            return tags;
        }

        public  async Task<List<Tag>> SearchTagAsync(string searchTerm)
        {
            var results = await context.Tags
                .Where(x => EF.Functions.Like(x.Tagname, $"%{searchTerm}%"))
                .Take(5)
                .ToListAsync();
            return results;
        }

    }
}
