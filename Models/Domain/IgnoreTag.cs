namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain
{
    public class IgnoreTag
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid TagId { get; set; }
        public Tag Tag { get; set; }

        public DateTime IgnoredAt { get; set; } = DateTime.Now;
    }
}
