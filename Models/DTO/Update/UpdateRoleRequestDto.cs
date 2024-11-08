namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Update
{
    public class UpdateRoleRequestDto
    {
        public string RoleName { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime UpdatedAt { get; set; }

        //Những người thuộc role này liệu có được chỉnh sửa không?

        /*public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();*/
    }
}
