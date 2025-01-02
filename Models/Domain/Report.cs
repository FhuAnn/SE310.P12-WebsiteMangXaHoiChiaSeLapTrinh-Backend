namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain
{
    public class Report
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }  // Người report
        public Guid PostId { get; set; }  // Bài viết bị report
        public string Reason { get; set; }  // Lý do report
        public DateTime ReportedAt { get; set; } = DateTime.Now;

        // Khóa ngoại
        public User User { get; set; }
        public Post Post { get; set; }
    }
}
