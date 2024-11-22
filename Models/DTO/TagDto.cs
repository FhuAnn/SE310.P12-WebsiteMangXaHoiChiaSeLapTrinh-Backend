using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO
{
    public class TagDto
    {
        public Guid? Id { get; set; }    

        public string Tagname { get; set; } = null!;

        public string Description { get; set; } = null!;
        public virtual ICollection<PosttagDto>? Posttags { get; set; } = new List<PosttagDto>();
    }
}
