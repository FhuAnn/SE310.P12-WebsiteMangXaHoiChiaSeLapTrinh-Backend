using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement
{
    public class SQLPosttagRepository : StackOverflowRepository<Posttag>, IPosttagRepository
    {
        private readonly Stackoverflow1511Context context;

        public SQLPosttagRepository(Stackoverflow1511Context context) : base(context)
        {
            this.context = context;
        }
    }
}
