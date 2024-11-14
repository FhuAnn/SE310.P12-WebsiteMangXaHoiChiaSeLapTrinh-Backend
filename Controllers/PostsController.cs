using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Add;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Update;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.CustomValidateFilters;
using Microsoft.AspNetCore.Authorization;
using NZWalk.API.Repositories;
using Microsoft.AspNetCore.Hosting;
using NZWalk.API.Models.DTO;
using Azure.Core;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]

    public class PostsController : ControllerBase
    {
        private readonly IPostRepository postRepository;
        private readonly IMapper mapper;
        private readonly IPosttagRepository posttagRepository;
        private readonly IImageRepositiory imageRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;

        public PostsController(IPostRepository postRepository, IMapper mapper, IPosttagRepository posttagRepository, IImageRepositiory imageRepositiory,
            IWebHostEnvironment webHostEnvironment,IHttpContextAccessor httpContextAccessor)
        {
            this.postRepository = postRepository;
            this.mapper = mapper;
            this.posttagRepository = posttagRepository;
            this.imageRepository = imageRepositiory;
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {


            //Get Data from Database - Domain models
            var postDomain = await postRepository.GetAllAsync();

            /*var tagList = await*/


            //Convert Domain to Dto
            return Ok(mapper.Map<List<PostDto>>(postDomain));
        }

        [HttpGet("postshome")]
 
        public async Task<IActionResult> GetPostsHome()
        {


            //Get Data from Database - Domain models
            var postDomain = await postRepository.GetPostHomesAsync();
   
            /*var tagList = await*/


            //Convert Domain to Dto
            return Ok(mapper.Map<List<PostDto>>(postDomain));
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetById(Guid id)
        {
            //Get answer model from DB
            var postDomain = await postRepository.GetByIdAsync(x => x.Id == id);

            if (postDomain == null)
            {
                return NotFound();
            }

            //Return DTO back to client
            return Ok(mapper.Map<PostDto>(postDomain));
        }
        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ValidateModel]
        public async Task<ActionResult<Post>> CreatePost([FromBody] AddPostRequestDto addPostDto)
        {
            //Convert DTO to Domain Model
            var postDomain = mapper.Map<Post>(addPostDto);

            //Use Domain Model to create Post
            postDomain = await postRepository.CreateAsync(postDomain);
           

            if( postDomain == null)
            {
                return BadRequest("Da xay ra loi , Khong tao post duoc");
            }

            foreach(var item in addPostDto.TagId)
            {

                var posttag = await posttagRepository.CreateAsync(new Posttag
                {
                    PostId = postDomain.Id,
                    TagId = item
                });

                if (posttag == null) return BadRequest("Da xay ra loi, Khong tao post duoc");
            }
            //Convert Domain Model back to DTO
            return Ok("tao post thanh cong");
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<IActionResult> UpdatePost(Guid id, UpdatePostRequestDto updatePostRequestDto)
        {
            //Map DTO to Domain Model
            var postDomain = mapper.Map<Post>(updatePostRequestDto);

            //Check if region exits
            postDomain = await postRepository.UpdateAsync(x => x.Id == id, entity =>
            {
                entity.DetailProblem = postDomain.DetailProblem;
                entity.Id = postDomain.Id;
            });
            if (postDomain == null) { return NotFound(); }

            //Convert Domain Model to DTO
            return Ok(mapper.Map<PostDto>(postDomain));

        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            //Check if region exits
            var postDomain = postRepository.DeleteAsync(x => x.Id == id);
            if (postDomain == null) { return NotFound(); }

            //Map Domain Model to DTO
            return Ok(mapper.Map<Post>(postDomain));
        }

        [HttpGet]
        [Route("details/{postId}")]
        public async Task<ActionResult> GetPostDetails(Guid postId)
        {
            var postDomain = await postRepository.GetPostDetailsAsync(postId);

            if (postDomain == null)
            {
                return NotFound();
            }

            // Chuyển đổi dữ liệu thành DTO
            var postDto = mapper.Map<PostDto>(postDomain);

            return Ok(postDto);
        }

        [HttpPost("UploadImages/{postId}")]
        public async Task<IActionResult> UploadImages(Guid postId, [FromForm] List<IFormFile> files)
        {
            var post = await postRepository.GetPostById(postId);
            if (post == null)
            {
                return NotFound("Post not found.");
            }
            if (files.Count()==0)
            {
                return BadRequest("File List is empty!");
            }
            var imageListDto = new List<ImageDto>();

            foreach (var file in files)
            {
                ValidateFileUpload(file);
                if (ModelState.IsValid)
                {
                    // Kiểm tra và xử lý ảnh
                    var image = new Image
                    {
                        file = file,
                        fileExtension = Path.GetExtension(file.FileName),
                        fileSizeInBytes = file.Length,
                        postId=postId
                        //FilePath = await SaveImageToLocal(file)
                    };
                    if (image.postId == null && image.postId == null)
                    {
                        return BadRequest("Ảnh phải liên kết với ít nhất một Post hoặc User.");
                    }
                    // Lưu ảnh vào cơ sở dữ liệu
                    image = await imageRepository.Upload( image);
                    var imageDto = mapper.Map<ImageDto>(image);
                    imageListDto.Add(imageDto);
                    continue;
                }
                return BadRequest(ModelState);
            }
            return Ok(imageListDto);
        }
        private void ValidateFileUpload(IFormFile file)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
            if (!allowedExtensions.Contains(Path.GetExtension(file.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension");

                if (file.Length > 10485760)
                {
                    ModelState.AddModelError("file", "File size more than 10MB, please upload a smaller size file");
                }
            }
        }
    }
}
