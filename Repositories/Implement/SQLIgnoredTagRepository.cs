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
    }
}
