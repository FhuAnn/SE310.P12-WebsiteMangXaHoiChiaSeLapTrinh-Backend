using System.ComponentModel.DataAnnotations;

namespace NZWalk.API.Models.DTO
{
    public class ImagesUploadRequestDto
    {
        public Guid postId;
        [Required]
        public IFormFile File { get; set; }
    }
}
