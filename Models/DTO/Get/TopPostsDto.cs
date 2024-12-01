namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Get
{
    public class TopPostsDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string DetailProblem { get; set; } = null!; 

        public string TryAndExpecting { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public int Upvote { get; set; }
        public int Downvote { get; set; }
        public virtual ICollection<AnswerDto> Answers { get; set; } = new List<AnswerDto>();
    }
}
