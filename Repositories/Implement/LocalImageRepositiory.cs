using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalk.API.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace NZWalk.API.Repositories
{
    public class LocalImageRepositiory : IImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly Stackoverflow1511Context dbContext;

        public LocalImageRepositiory(IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            Stackoverflow1511Context dbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
        }

        public async Task<List<string>> GetImageUrlsByPostId(Guid id)
        {
            var image = await dbContext.Images
                .Where(img => img.PostId == id)
                .Select(img => new Image
                {
                    FilePath = img.FilePath,
                }).ToListAsync();

            var imgUrls = new List<string>();
            foreach (var img in image)
            {
                imgUrls.Add(img.FilePath);
            }
            return imgUrls;
        }

        public async Task<Image> Upload(Image image)
        {
            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var uniqueFileName = $"{Path.GetFileNameWithoutExtension(image.file.FileName)}_{timestamp}{Path.GetExtension(image.file.FileName)}";
            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath,"Images",
                uniqueFileName);
           //Upload Image to LocalPath 
            using var stream = new FileStream(localFilePath,FileMode.Create);
            await image.file.CopyToAsync(stream);

            //E;/https://localjhost
            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}" +
                $"/Images/{uniqueFileName}";
            image.FilePath = urlFilePath;
            
            //Add Image to the Images table
            await dbContext.Images.AddAsync(image);
            await dbContext.SaveChangesAsync();   

            return image;
        }
    }
}
