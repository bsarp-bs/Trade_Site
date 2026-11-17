using Microsoft.EntityFrameworkCore;
using Trade_Site_Auth_WebAPI.Context;
using Trade_Site_Auth_WebAPI.Models;

namespace Trade_Site_Auth_WebAPI.Services
{
    public class EfUserStoreService : IUserStoreService
    {
        private readonly AuthDbContext _context;

        public EfUserStoreService(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<bool> UserExistsAsync(string username, string email)
        {
            return await _context.AppUsers.AnyAsync(x =>
                x.Username.ToLower() == username.ToLower() ||
                x.Email.ToLower() == email.ToLower());
        }

        public async Task<AppUser> CreateUserAsync(string username, string email, string password)
        {
            var (hash, salt) = PasswordHasher.HashPassword(password);

            var user = new AppUser
            {
                Username = username,
                Email = email,
                PasswordHash = hash,
                PasswordSalt = salt,
                Role = "Visitor"
            };

            _context.AppUsers.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<AppUser?> ValidateUserAsync(string usernameOrEmail, string password)
        {
            var user = await _context.AppUsers.FirstOrDefaultAsync(x =>
                x.Username.ToLower() == usernameOrEmail.ToLower() ||
                x.Email.ToLower() == usernameOrEmail.ToLower());

            if (user == null)
            {
                return null;
            }

            var isValid = PasswordHasher.VerifyPassword(password, user.PasswordHash, user.PasswordSalt);
            return isValid ? user : null;
        }

        public async Task<AppUser?> GetByIdAsync(string id)
        {
            return await _context.AppUsers.FindAsync(id);
        }
    }
}
