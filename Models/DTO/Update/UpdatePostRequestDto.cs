using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Update
{
    public class UpdatePostRequestDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Tryandexpecting { get; set; } = null!;
        [Required]
        public string Detailproblem { get; set; } = null!;

    }
}
    