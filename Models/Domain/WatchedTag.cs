namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain
{
    public class WatchedTag
    {
        public Guid TagId { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Tag  Tag { get; set; }
    }
}
