using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Trade_Site_Cart_WebAPI.LoginService
{
    public class LoginServiceClass : ILoginService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginServiceClass(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId =>
            _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
            ?? _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
            ?? throw new UnauthorizedAccessException("Kullanici token bilgisi bulunamadi.");
    }
}
