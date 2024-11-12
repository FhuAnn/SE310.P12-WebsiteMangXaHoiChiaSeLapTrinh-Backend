using System.ComponentModel.DataAnnotations;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Update
{
    public class UpdateRoleRequestDto
    {
        [Required]
        public string RoleName { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

    }
}
