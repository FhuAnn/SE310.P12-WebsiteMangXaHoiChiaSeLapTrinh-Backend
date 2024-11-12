using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Update
{
    public class UpdateCommentRequestDto
    {
        [Required]
        public string Body { get; set; } = null!;

        [Required]
        public DateTime UpdatedAt { get; set; }

    }
}
