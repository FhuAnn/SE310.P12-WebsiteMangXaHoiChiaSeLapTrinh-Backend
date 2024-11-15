using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO
{
    public class TagDto
    {
        public Guid Id { get; set; }

        public string Tagname { get; set; } = null!;

        public string Description { get; set; } = null!;

        public virtual ICollection<PostDto> Posts { get; set; } = new List<PostDto>();
            
    }
}
