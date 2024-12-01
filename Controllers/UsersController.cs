using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalk.API.Repositories;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Add;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Update;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly IImageRepository imageRepository;

        public UsersController(IUserRepository userRepository,
            IMapper mapper,IImageRepository imageRepository)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.imageRepository = imageRepository;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            //Get Data from Database - Domain models
            var userDomain = await userRepository.GetAllUserAsync();
            //Convert Domain to Dto
            return Ok(mapper.Map<List<UserDto>>(userDomain));
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            var user = await userRepository.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<UserDto>(user));
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, UpdateUserRequestDto updateCommentRequestDto)
        {
            var userDomain = mapper.Map<User>(updateCommentRequestDto);

            //Check if region exits
            userDomain = await userRepository.UpdateAsync(x => x.Id == id, entity =>
            {
                entity.Username = updateCommentRequestDto.Username;
                entity.Email = updateCommentRequestDto.Email;
                entity.Gravatar = updateCommentRequestDto.Gravatar;
                entity.UpdatedAt= DateTime.Now;
            });
            if (userDomain == null) { return NotFound(); }

            //Convert Domain Model to DTO
            return Ok(mapper.Map<UserDto>(userDomain));
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var userInsert = await userRepository.CreateAsync(user);

            return CreatedAtAction("GetUser", new { id = userInsert.Id }, userInsert);
        }*/

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await userRepository.DeleteAsync(u => u.Id == id);

            return NoContent();
        }

        [HttpPost("uploadImages")]
        public async Task<IActionResult> UploadImages([FromForm] AddImageRequetstDto inputFile)
        {
            var post = await userRepository.GetByIdAsync(u => u.Id == inputFile.targetId);

            if (post == null)
            {
                return NotFound("User not found.");
            }
            ValidateFileUpload(inputFile.file);
            if (ModelState.IsValid)
            {
           
                // Kiểm tra và xử lý ảnh
                var image = new Image
                {
                    file = inputFile.file,
                    fileExtension = Path.GetExtension(inputFile.file.FileName),
                    fileSizeInBytes = inputFile.file.Length,
                    userId = inputFile.targetId
                    //FilePath = await SaveImageToLocal(file)
                };
                
                // Lưu ảnh vào cơ sở dữ liệu
                image = await imageRepository.Upload(image);
                var imageDto = mapper.Map<ImageDto>(image);
                return Ok(imageDto);

            }
            return BadRequest(ModelState);

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
