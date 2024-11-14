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
        public ImagesController(IImageRepositiory imageRepositiory)
        {
            ImageRepositiory = imageRepositiory;
        }

        public IImageRepositiory ImageRepositiory { get; }

        //Post: api/Images/Upload
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> UpLoad([FromForm] ImagesUploadRequestDto request)
        {

            ValidateFileUpload(request);
            if (ModelState.IsValid)
            {
                //convert DTO to Domain Model
                var imageDomainModel = new Image
                {
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length,
                    FileName = request.FileName,
                    FileDescription = request.FileDescription,
                };

                //user repository to upload image
                await ImageRepositiory.Upload(imageDomainModel);
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
