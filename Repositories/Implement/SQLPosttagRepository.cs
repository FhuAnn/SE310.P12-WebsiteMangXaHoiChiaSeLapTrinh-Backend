using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement
{
    public class SQLPosttagRepository : StackOverflowRepository<Posttag>, IPosttagRepository
    {
        private readonly StackOverflowDBContext context;

        public SQLPosttagRepository(StackOverflowDBContext context) : base(context)
        {
            this.context = context;
        }
    }
}
