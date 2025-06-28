using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Screen
{
    public class TagScreenDto
    {
        public Guid Id { get; set; }

        public string Tagname { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
