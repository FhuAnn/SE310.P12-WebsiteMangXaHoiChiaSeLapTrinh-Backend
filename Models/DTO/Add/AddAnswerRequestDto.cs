using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Add
{
    public class AddAnswerRequestDto
    {
        [Required]
        public string Body { get; set; } = null!;
        

        [Required]
        public Guid? UserId { get; set; }

        [Required]
        public Guid? PostId { get; set; }
  

    }
}
