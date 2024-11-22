namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO
{
    public class UserRoleDto
    {

        public Guid RoleId { get; set; }

        public DateTime AssignedAt { get; set; } = DateTime.Now;
    }
}
