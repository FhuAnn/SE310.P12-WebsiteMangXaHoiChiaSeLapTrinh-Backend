using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement
{
    public class SQLWatchedTagRepository : StackOverflowRepository<WatchedTag>, IWatchedTagRepository
    {
        private readonly Stackoverflow1511Context dbcontext;

        public SQLWatchedTagRepository(Stackoverflow1511Context dbcontext) : base(dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<List<Tag>> GetWatchedTagByUserIdAsync(Guid userId)
        {
            var watchedTags =await dbcontext.WatchedTags
                .Where(wt => wt.UserId == userId).ToListAsync();
            List<Tag> tags = new List<Tag>();
            foreach (var watchedTag in watchedTags)
            {
                var tag = await dbcontext.Tags.Where(t => t.Id == watchedTag.TagId).FirstOrDefaultAsync();
                tags.Add(tag);   
            }    
            return tags;
        }
    }
}
