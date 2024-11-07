using Microsoft.EntityFrameworkCore;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement
{
    public class SQLRoleRepository : IRoleRepository
    {
        private readonly StackOverflowDBContext dbContext;

        public SQLRoleRepository(StackOverflowDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Role> CreateAsync(Role role)
        {
            await dbContext.Roles.AddAsync(role);
            await dbContext.SaveChangesAsync();
            return role;
        }

        public async Task<Role> DeleteAsync(Guid id)
        {
            var existingRole = await dbContext.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRole == null)
            {
                return null;
            }

            dbContext.Roles.Remove(existingRole);
            await dbContext.SaveChangesAsync();
            return existingRole;
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await dbContext.Roles.ToListAsync();
        }

        public async Task<Role> GetByIdAsync(Guid id)
        {
            return await dbContext.Roles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Role> UpdateAsync(Guid id, Role role)
        {
            var existingRole = dbContext.Roles.FirstOrDefault(x => x.Id == id);
            if (existingRole == null)
            {
                return null;
            }
            //Only Change Body and UpdateAt and RoleName
            existingRole.UpdatedAt = role.UpdatedAt;
            existingRole.Description = role.Description;
            existingRole.RoleName = role.RoleName;

            await dbContext.SaveChangesAsync();
            return existingRole;
        }
    }
}
