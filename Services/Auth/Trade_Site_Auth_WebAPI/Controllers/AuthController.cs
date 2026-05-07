using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Trade_Site_Auth_WebAPI.DTOs;
using Trade_Site_Auth_WebAPI.Services;

namespace Trade_Site_Auth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserStoreService _userStoreService;
        private readonly ITokenService _tokenService;

        public AuthController(IUserStoreService userStoreService, ITokenService tokenService)
        {
            _userStoreService = userStoreService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) ||
                string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("Username, email ve password zorunludur.");
            }

            var exists = await _userStoreService.UserExistsAsync(request.Username, request.Email);
            if (exists)
            {
                return BadRequest("Bu username veya email zaten kullaniliyor.");
            }

            var user = await _userStoreService.CreateUserAsync(request.Username, request.Email, request.Password);
            var token = _tokenService.CreateToken(user);

            return Ok(token);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.UsernameOrEmail) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("Username/email ve password zorunludur.");
            }

            var user = await _userStoreService.ValidateUserAsync(request.UsernameOrEmail, request.Password);
            if (user == null)
            {
                return Unauthorized("Kullanici bilgileri hatali.");
            }

            var token = _tokenService.CreateToken(user);
            return Ok(token);
        }

        [Authorize]
        [HttpGet("me")]
        public IActionResult Me()
        {
            return Ok(new
            {
                UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub)
                         ?? User.FindFirstValue(ClaimTypes.NameIdentifier),

                Username = User.FindFirstValue(ClaimTypes.Name)
                           ?? User.FindFirstValue(JwtRegisteredClaimNames.UniqueName),

                Email = User.FindFirstValue(ClaimTypes.Email)
                        ?? User.FindFirstValue(JwtRegisteredClaimNames.Email),

                Role = User.FindFirstValue(ClaimTypes.Role)
            });
        }
    }
}
