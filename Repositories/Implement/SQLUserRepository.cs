using Microsoft.EntityFrameworkCore;
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

       

        public async Task<User> Authenticate(string email, string password)
        {
            var result = await context.Users.SingleOrDefaultAsync(user => user.Email.Equals(email) && user.Password.Equals(password));
            return result;
        }
    }
}
