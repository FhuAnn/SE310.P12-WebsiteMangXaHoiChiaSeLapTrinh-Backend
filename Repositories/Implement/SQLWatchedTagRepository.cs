using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement
{
    public class SQLWatchedTagRepository : StackOverflowRepository<WatchedTag>, IWatchedTagRepository
    {
        private readonly StackOverflowDBContext dbcontext;

        public SQLWatchedTagRepository(StackOverflowDBContext dbcontext) : base(dbcontext)
        {
            this.dbcontext = dbcontext;
        }
    }
}
