using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NZWalk.API.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace NZWalk.API.Repositories
{
    public class LocalImageRepositiory : IImageRepositiory
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly StackOverflowDBContext dbContext;

        public LocalImageRepositiory(IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            StackOverflowDBContext dbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
        }
        public async Task<Image> Upload(Image image)
        {
           
            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath,"Images", 
                $"{image.file.FileName}");
           //Upload Image to LocalPath 
            using var stream = new FileStream(localFilePath,FileMode.Create);
            await image.file.CopyToAsync(stream);

            //E;/https://localjhost
            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.file.FileName}";
            image.filePath = urlFilePath;
            
            //Add Image to the Images table
            await dbContext.Images.AddAsync(image);
            await dbContext.SaveChangesAsync();   

            return image;
        }
    }
}
