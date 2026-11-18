using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Data;
using Trade_Site_Price_Drop.Entity;

namespace Trade_Site_Price_Drop.Context
{
    public class PriceDropContextFactory : DbContext
    {
        private readonly IConfiguration _configuration;

        private readonly string _connectionstring;

        public PriceDropContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Same connection string Dapper uses (ConnectionStrings:DefaultConnection), so EF migrations and queries hit one database.
            optionsBuilder.UseSqlServer(_connectionstring);
        }

        public DbSet<Discount> Discounts { get; set; }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionstring);
    }
}
