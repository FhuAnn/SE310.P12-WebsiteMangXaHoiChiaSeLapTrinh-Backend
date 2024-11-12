using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Update
{
    public class UpdatePostRequestDto
    {
        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Body { get; set; } = null!;

        public int Views { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

    }
}
