using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using System.Text.Json.Serialization;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO
{
    public class PostDto
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

        public virtual ICollection<AnswerDto> Answers { get; set; } = new List<AnswerDto>();

        public virtual ICollection<PosttagDto> Posttags { get; set; } = new List<PosttagDto>();

        public virtual UserDto? User { get; set; }
        public List<string>? ImageUrls { get; set; } = new List<string>();

    }
}
