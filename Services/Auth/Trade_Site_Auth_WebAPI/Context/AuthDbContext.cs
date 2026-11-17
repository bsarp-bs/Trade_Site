using Microsoft.EntityFrameworkCore;
using Trade_Site_Auth_WebAPI.Models;

namespace Trade_Site_Auth_WebAPI.Context
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).HasMaxLength(64);
                entity.Property(x => x.Username).IsRequired().HasMaxLength(100);
                entity.Property(x => x.Email).IsRequired().HasMaxLength(200);
                entity.Property(x => x.PasswordHash).IsRequired();
                entity.Property(x => x.PasswordSalt).IsRequired();
                entity.Property(x => x.Role).IsRequired().HasMaxLength(50);

                entity.HasIndex(x => x.Username).IsUnique();
                entity.HasIndex(x => x.Email).IsUnique();
            });
        }
    }
}
