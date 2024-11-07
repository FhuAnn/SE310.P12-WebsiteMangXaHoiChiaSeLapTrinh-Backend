using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Update
{
    public class UpdatePostRequestDto
    {
        public string Title { get; set; } = null!;

        public string Body { get; set; } = null!;

        public int Views { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
