using Trade_Site_Auth_WebAPI.DTOs;
using Trade_Site_Auth_WebAPI.Models;

namespace Trade_Site_Auth_WebAPI.Services
{
    public interface ITokenService
    {
        AuthResponseDto CreateToken(AppUser user);
    }
}
