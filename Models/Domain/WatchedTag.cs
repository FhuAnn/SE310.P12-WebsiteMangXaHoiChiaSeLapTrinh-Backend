namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain
{
    public class WatchedTag
    {
        public Guid UserId { get; set; }
        public Guid TagId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual Tag Tag { get; set; } = null!;
    }
}
