namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Get
{
    public class PostReportDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Tryandexpecting { get; set; } 

        public int Views { get; set; }

        public DateTime CreatedAt { get; set; } 

        public DateTime UpdatedAt { get; set; } 
        public int reportCount { get; set; }
    }
}
