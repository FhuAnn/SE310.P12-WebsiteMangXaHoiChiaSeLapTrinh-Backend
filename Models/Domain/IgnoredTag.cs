namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain
{
    public class IgnoredTag
    {
        public Guid TagId { get; set; }
        public Guid UserId { get; set; }

        public User User { get; set; }
        public Tag Tag { get; set; }
    }
}
