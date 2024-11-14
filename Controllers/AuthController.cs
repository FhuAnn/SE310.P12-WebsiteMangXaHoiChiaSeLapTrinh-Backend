using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IUserRoleRepository userRoleRepository;
        private readonly ITokenService tokenService;

        public AuthController(IUserRepository userRepository, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository, ITokenService tokenService)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.userRoleRepository = userRoleRepository;
            this.tokenService = tokenService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var user = new User
            {
                //Email = registerRequestDto.Email,
                Username = registerRequestDto.Username,
                Password = registerRequestDto.Password
            };

            var userCreateResult = await userRepository.CreateAsync(user);


            if (userCreateResult != null)
            {
                // Add roles to this User

                var role = await roleRepository.GetRoleByName("newbie");
                var result = await userRoleRepository.CreateAsync(new UserRole
                {
                    UserId = userCreateResult.Id,
                    RoleId = role.Id
                });

                if (result != null)
                {
                    return Ok("User was registered! Please login");
                }

            }

            return BadRequest("Something went wrong");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {

            var user = await userRepository.Authenticate(loginRequestDto.Email, loginRequestDto.Password);

            if (user != null)
            {

                // get role
                var role = await userRoleRepository.GetUserRole(user.Id);
                if (role != null)
                {
                    // create token

                    var jwttoken = tokenService.CreateJWTToken(user, role.ToList());

                    var loginResponse = new LoginResponseDto
                    {
                        UserId = user.Id,
                        JwtToken = jwttoken,
                    };
                    return Ok(loginResponse);
                }




            }

            return BadRequest("Username or password incorrect");
        }
    }
}
