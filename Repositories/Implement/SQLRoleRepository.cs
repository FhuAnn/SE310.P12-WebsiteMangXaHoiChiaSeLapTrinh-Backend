using Microsoft.EntityFrameworkCore;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement
{
    public class SQLRoleRepository : StackOverflowRepository<Role>,IRoleRepository
    {
        private readonly Stackoverflow1511Context dbContext;

        public SQLRoleRepository(Stackoverflow1511Context dbContext):base(dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task<Role> GetRoleByName(string roleName)
        {
            var result = await dbContext.Roles.SingleOrDefaultAsync(r => r.RoleName.Equals(roleName));
            if(result == null)
            {
                return null;
            }
            return result;
        }
    }
}
