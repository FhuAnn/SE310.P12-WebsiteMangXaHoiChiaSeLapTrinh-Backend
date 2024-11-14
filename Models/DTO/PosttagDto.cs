using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO
{
    public class PosttagDto
    {
        public Guid PostId { get; set; }

        public Guid TagId { get; set; }
    /*    public virtual PostDto Post { get; set; } = null!;*/

        public virtual TagDto Tag { get; set; } = null!;
    }
}
