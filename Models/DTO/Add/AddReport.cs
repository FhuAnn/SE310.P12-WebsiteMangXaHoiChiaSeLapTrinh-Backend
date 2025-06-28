namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Add
{
    public class AddReport
    {
        public Guid UserId { get; set; }  // Người report
        public Guid PostId { get; set; }  // Bài viết bị report
        public string Reason { get; set; }
    }
}
