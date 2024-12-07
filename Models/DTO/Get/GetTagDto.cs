using Microsoft.AspNetCore.Http.HttpResults;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Get
{
    public class GetTagDto
    {
        public Guid? Id { get; set; }
        public string Tagname { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
