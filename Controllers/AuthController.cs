using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Services;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMemoryCache cache;
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IUserRoleRepository userRoleRepository;
        private readonly ITokenService tokenService;
        private readonly EmailService _emailService;

        public AuthController(IMemoryCache cache, IUserRepository userRepository, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository, ITokenService tokenService)
        {
            this.cache = cache;
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.userRoleRepository = userRoleRepository;
            this.tokenService = tokenService;
            _emailService = new EmailService();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var user = new User
            {
                Email = registerRequestDto.Email,
                Username = registerRequestDto.Username,
                Password = registerRequestDto.Password
            };

            var userExisting = await userRepository.GetUserByEmailAsync(user.Email);
            if (userExisting == null)
            {
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
            }
            else
            {
                return BadRequest("User's email is existing");
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

        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangePasswordRequest request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.NewPassword))
            {
                return BadRequest(new
                {
                    status = "error",
                    message = "Email và mật khẩu mới không được để trống."
                });
            }

            try
            {
                var userToChangePassword = await userRepository.GetUserByEmailAsync(request.Email);

                if (userToChangePassword == null)
                {
                    return NotFound(new
                    {
                        status = "error",
                        message = "Không tìm thấy người dùng với email đã cung cấp."
                    });
                }

                await userRepository.UpdatePassword(userToChangePassword, request.NewPassword);
                return Ok(new
                {
                    status = "success",
                    message = "Đổi mật khẩu thành công."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = "error",
                    message = ex.Message
                });
            }
        }



        [HttpPost("validateUser")]
        public async Task<IActionResult> ValidateUser([FromBody] LoginRequestDto request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest(new
                {
                    status = "error",
                    message = "Email và mật khẩu không được để trống."
                });
            }

            try
            {
                var user = await userRepository.Authenticate(request.Email, request.Password);

                if (user == null)
                {
                    return Unauthorized(new
                    {
                        status = "error",
                        message = "Email hoặc mật khẩu không đúng."
                    });
                }

                return Ok(new
                {
                    status = "success",
                    message = "Xác thực thành công."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = "error",
                    message = ex.Message
                });
            }
        }


        [HttpPost("send-verification-code/{email}")]
        public async Task<IActionResult> SendVerificationCode(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest(new
                {
                    status = "error",
                    message = "Email không được để trống."
                });
            }

            try
            {
                var code = await _emailService.SendVerificationCodeAsync(email);
                cache.Set(email, code, TimeSpan.FromMinutes(5));

                return Ok(new
                {
                    status = "success",
                    message = "Mã xác nhận đã được gửi đến email của bạn."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    status = "error",
                    message = "Đã xảy ra lỗi khi gửi mã xác nhận.",
                    details = ex.Message // (tuỳ chọn)
                });
            }
        }

        [HttpPost("verify-code")]
        public IActionResult VerifyCode([FromBody] VerifyCodeRequest request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Code))
            {
                return BadRequest(new
                {
                    status = "error",
                    message = "Email và mã xác nhận không được để trống."
                });
            }

            if (cache.TryGetValue(request.Email, out string storedCode))
            {
                if (storedCode == request.Code)
                {
                    cache.Remove(request.Email);
                    return Ok(new
                    {
                        status = "success",
                        message = "Mã xác nhận chính xác. Bạn có thể tiếp tục."
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        status = "error",
                        message = "Mã xác nhận không đúng. Vui lòng thử lại."
                    });
                }
            }

            return BadRequest(new
            {
                status = "expired",
                message = "Mã xác nhận đã hết hạn hoặc không tồn tại."
            });
        }

    }
}
