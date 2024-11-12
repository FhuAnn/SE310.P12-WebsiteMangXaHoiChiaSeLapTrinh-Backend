using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO
{
    public class HomePostDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Body { get; set; } = null!;

        public int Views { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string Username { get; set; } = null!;
        public int Upvote { get; set; }

        public int Downvote { get; set; }
        public IEnumerable<string> TagList { get; set; }

    }
}
