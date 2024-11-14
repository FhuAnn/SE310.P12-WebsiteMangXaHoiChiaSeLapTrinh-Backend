using Microsoft.EntityFrameworkCore;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement
{
    public class SQLUserRoleRepository : StackOverflowRepository<UserRole>, IUserRoleRepository
    {
        private readonly StackOverflowDBContext context;

        public SQLUserRoleRepository(StackOverflowDBContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<ICollection<string>> GetUserRole(Guid userId)
        {
           
            var result = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .SelectMany(u => u.UserRoles.Select(ur => ur.Role.RoleName))
                .ToListAsync();
            return result;
        }
    }
}
