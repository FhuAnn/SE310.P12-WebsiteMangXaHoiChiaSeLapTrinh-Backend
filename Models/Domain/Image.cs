using System.ComponentModel.DataAnnotations.Schema;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain
{
    public class Image
    {
        public Guid id { get; set; }
        [NotMapped]
        public IFormFile file { get; set; }
        public string fileExtension { get; set; }
        public long fileSizeInBytes { get; set; }
        public string filePath { get; set; }

        public Guid? postId { get; set; }
        public virtual Post Post { get; set; }

        public Guid? userId { get; set; }
        public virtual User User
        {
            get; set;
        }
    }
}
