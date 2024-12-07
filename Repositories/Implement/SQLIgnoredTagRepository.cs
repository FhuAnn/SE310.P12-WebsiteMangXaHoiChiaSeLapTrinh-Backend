using Microsoft.EntityFrameworkCore;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement
{
    public class SQLIgnoredTagRepository : StackOverflowRepository<IgnoredTag>, IIgnoreTagRepository
    {
        private readonly StackOverflowDBContext dbcontext;

        public SQLIgnoredTagRepository(StackOverflowDBContext dbcontext) : base(dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<List<Tag>> GetIgnoredTagByUserIdAsync(Guid userId)
        {
            var ignoredTags = await dbcontext.IgnoredTags
                .Where(wt => wt.UserId == userId).ToListAsync();
            List<Tag> tags = new List<Tag>();
            foreach (var ignoredTag in ignoredTags)
            {
                var tag = await dbcontext.Tags.Where(t => t.Id == ignoredTag.TagId).FirstOrDefaultAsync();
                tags.Add(tag);
            }
            return tags;
        }
    }
}
