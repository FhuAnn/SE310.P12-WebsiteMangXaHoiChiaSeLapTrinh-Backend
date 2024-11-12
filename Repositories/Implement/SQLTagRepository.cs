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
    }
}
