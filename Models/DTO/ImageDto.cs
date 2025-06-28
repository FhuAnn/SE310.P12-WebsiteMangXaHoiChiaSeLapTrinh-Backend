using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO
{
    public class ImageDto
    {
        public string filePath { get; set; }

        public Guid? postId { get; set; }

        public Guid? userId { get; set; }
    }
}   
