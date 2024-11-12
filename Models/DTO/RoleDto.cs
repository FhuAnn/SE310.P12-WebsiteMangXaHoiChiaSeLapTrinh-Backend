using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO
{
    public class RoleDto
    {
        public Guid Id { get; set; }

        public string RoleName { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        //public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
