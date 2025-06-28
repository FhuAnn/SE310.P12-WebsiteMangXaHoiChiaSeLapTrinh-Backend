using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Add
{
    public class AddPostRequestDto
    {

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string DetailProblem { get; set; } = null!;
        [Required]
        public string TryAndExpecting { get; set; } = null!;

        [Required]
        public List<Guid> TagId { get; set; } = null!;
        [Required]
        public Guid? UserId { get; set; }
        public List<IFormFile>? ImageFiles { get; set; } 
    }
}
