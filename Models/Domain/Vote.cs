namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain
{
    public class Vote
    {
        public Guid Id { get; set; }= Guid.NewGuid();
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public int VoteType { get; set; }  // 1 = Upvote, -1 = Downvote
        public DateTime VotedAt { get; set; } = DateTime.Now;
        public User User { get; set; }
        public Post Post { get; set; }
    }
}
