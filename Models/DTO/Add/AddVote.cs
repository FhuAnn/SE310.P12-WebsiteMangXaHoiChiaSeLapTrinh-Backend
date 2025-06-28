namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Add
{
    public class AddVote
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public int VoteType { get; set; }
    }
}
