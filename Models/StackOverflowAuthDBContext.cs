using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models
{
    public class StackOverflowAuthDBContext:IdentityDbContext
    {
        public StackOverflowAuthDBContext(DbContextOptions<StackOverflowAuthDBContext> options):base(options)
        {
                    
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readRoleId = "e23f1c20-381e-4532-9317-001e05cf3f93";
            var writerRoleId = "741a8096-97b0-4673-a419-be19092d585a";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id= readRoleId,
                    ConcurrencyStamp = readRoleId,
                    Name="Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                 new IdentityRole
                {
                      Id= writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name="Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
