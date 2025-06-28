namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Get
{
    public class VoteDto
    {
        public Guid Id { get; set; } 
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public int VoteType { get; set; }  // 1 = Upvote, -1 = Downvote
        public DateTime VotedAt { get; set; }
    }
}
