using System.ComponentModel.DataAnnotations;

namespace NZWalk.API.Models.DTO
{
    public class ImagesUploadRequestDto
    {
        [Required]
        public IFormFile File { get; set; }
    }
}
