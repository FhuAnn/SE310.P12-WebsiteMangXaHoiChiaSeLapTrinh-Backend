using System.ComponentModel.DataAnnotations;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Update
{
    public class UpdateAnswerRequestDto
    {
        [Required]
        public string Body { get; set; } = null!;
        
    }
}
