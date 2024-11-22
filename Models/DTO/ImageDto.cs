using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO
{
    public class ImageDto
    {
        public Guid id { get; set; }
        [NotMapped]
        public IFormFile file { get; set; }
        public string fileExtension { get; set; }
        public long fileSizeInBytes { get; set; }
        public string filePath { get; set; }

        public Guid? postId { get; set; }
        public virtual PostDto Post { get; set; }

        public Guid? userId { get; set; }
        public virtual UserDto User
        {
            get; set;
        }
    }
}   
