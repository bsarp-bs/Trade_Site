using System.Collections.Concurrent;
using Trade_Site_Auth_WebAPI.Models;

namespace Trade_Site_Auth_WebAPI.Services
{
    public class InMemoryUserStoreService : IUserStoreService
    {
        private readonly ConcurrentDictionary<string, AppUser> _users = new();

        public Task<bool> UserExistsAsync(string username, string email)
        {
            var exists = _users.Values.Any(x =>
                x.Username.Equals(username, StringComparison.OrdinalIgnoreCase) ||
                x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            return Task.FromResult(exists);
        }

        public Task<AppUser> CreateUserAsync(string username, string email, string password)
        {
            var (hash, salt) = PasswordHasher.HashPassword(password);

            var user = new AppUser
            {
                Username = username,
                Email = email,
                PasswordHash = hash,
                PasswordSalt = salt
            };

            _users[user.Id] = user;

            return Task.FromResult(user);
        }

        public Task<AppUser?> ValidateUserAsync(string usernameOrEmail, string password)
        {
            var user = _users.Values.FirstOrDefault(x =>
                x.Username.Equals(usernameOrEmail, StringComparison.OrdinalIgnoreCase) ||
                x.Email.Equals(usernameOrEmail, StringComparison.OrdinalIgnoreCase));

            if (user == null)
            {
                return Task.FromResult<AppUser?>(null);
            }

            var isValid = PasswordHasher.VerifyPassword(password, user.PasswordHash, user.PasswordSalt);
            return Task.FromResult(isValid ? user : null);
        }

        public Task<AppUser?> GetByIdAsync(string id)
        {
            _users.TryGetValue(id, out var user);
            return Task.FromResult(user);
        }
    }
}
