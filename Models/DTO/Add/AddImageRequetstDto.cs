using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Add
{
    public class AddImageRequetstDto
    {
        [Required]
        public IFormFile file { get; set; }
        [Required]
        public Guid targetId { get; set; }
    }
}
