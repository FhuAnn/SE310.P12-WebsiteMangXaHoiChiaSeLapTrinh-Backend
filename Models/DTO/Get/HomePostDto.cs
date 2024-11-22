using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Get
{
    public class HomePostDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string DetailProblem { get; set; } = null!;

        public string TryAndExpecting { get; set; } = null!;

        public int Views { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid? UserId { get; set; }
        public int Upvote { get; set; }
        public int Downvote { get; set; }
        public virtual ICollection<HomePostTagDto> Posttags { get; set; } = new List<HomePostTagDto>();
    }
}
