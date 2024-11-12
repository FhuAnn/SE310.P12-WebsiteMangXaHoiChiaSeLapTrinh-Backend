using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Add
{
    public class AddRoleRequestDto
    {
        [Required]
        public string RoleName { get; set; } = null!;

        [Required]
        public string? Description { get; set; }

       
    }
}
