using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Get
{
    public class ReportDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }  // Người report
        public Guid PostId { get; set; }  // Bài viết bị report
        public string Reason { get; set; }  // Lý do report
        public DateTime ReportedAt { get; set; }
        public MinimalUser User { get; set; }

        public bool isSelf {  get; set; } 
    }
}
    