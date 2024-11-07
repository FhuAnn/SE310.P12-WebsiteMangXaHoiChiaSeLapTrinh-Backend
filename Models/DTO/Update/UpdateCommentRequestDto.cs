using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Update
{
    public class UpdateCommentRequestDto
    {
        public string Body { get; set; } = null!;

        public DateTime UpdatedAt { get; set; }

    }
}
