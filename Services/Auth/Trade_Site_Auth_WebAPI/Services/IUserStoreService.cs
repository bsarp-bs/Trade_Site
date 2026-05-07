using Trade_Site_Auth_WebAPI.Models;

namespace Trade_Site_Auth_WebAPI.Services
{
    public interface IUserStoreService
    {
        Task<bool> UserExistsAsync(string username, string email);
        Task<AppUser> CreateUserAsync(string username, string email, string password);
        Task<AppUser?> ValidateUserAsync(string usernameOrEmail, string password);
        Task<AppUser?> GetByIdAsync(string id);
    }
}
