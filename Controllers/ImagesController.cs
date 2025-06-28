using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalk.API.Models.DTO;
using NZWalk.API.Repositories;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace NZWalk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepositiory;

        public ImagesController(IImageRepository imageRepositiory)
        {
            this.imageRepositiory = imageRepositiory;
        }
       
        //Post: api/Images/Upload
        [HttpPost]
        [Route("Upload/{PostId}")]
        public async Task<IActionResult> UpLoad([FromForm] ImagesUploadRequestDto request)
        {
            ValidateFileUpload(request);
            if (ModelState.IsValid)
            {
                //convert DTO to Domain Model
                var imageDomainModel = new Image
                {
                    file = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length
                };

                //user repository to upload image
                await imageRepositiory.Upload(imageDomainModel);
                return Ok(imageDomainModel);
            }
            return BadRequest(ModelState);
        }
        private void ValidateFileUpload(ImagesUploadRequestDto request)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
            if (!allowedExtensions.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension");

                if (request.File.Length > 10485760)
                {
                    ModelState.AddModelError("file", "File size more than 10MB, please upload a smaller size file");
                }
            }
        }
    }
}
