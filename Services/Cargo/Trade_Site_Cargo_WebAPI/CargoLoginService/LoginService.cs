using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Trade_Site_Cargo_WebAPI.CargoLoginService
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _httpContextAccessor = contextAccessor;
        }

        public string GetUserId =>
       _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
       ?? _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
       ?? throw new UnauthorizedAccessException("Kullanici token bilgisi bulunamadi.");
    }
}
