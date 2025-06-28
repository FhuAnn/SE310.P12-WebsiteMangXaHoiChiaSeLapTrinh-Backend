using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Get;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO
{
    public class CommentDto
    {
        public Guid Id { get; set; }

        public string Body { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid? UserId { get; set; }

        public Guid? PostId { get; set; }

        public Guid? AnswerId { get; set; }

        public virtual MinimalUser? User { get; set; }
    }
}
