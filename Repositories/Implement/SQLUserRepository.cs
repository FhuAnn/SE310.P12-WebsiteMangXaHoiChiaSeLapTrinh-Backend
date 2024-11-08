using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement
{
    public class SQLUserRepository : StackOverflowRepository<User>, IUserRepository
    {
        private readonly StackOverflowDBContext context;

        public SQLUserRepository(StackOverflowDBContext context) : base(context)
        {
            this.context = context;
        }
    }
}
