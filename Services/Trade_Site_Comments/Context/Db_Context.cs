using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Trade_Site_Comments.Entity;

namespace Trade_Site_Comments.Context
{
    public class Db_Context : DbContext
    {
        private readonly IConfiguration _configuration;

        private readonly string _connectionstring;

        public Db_Context(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;database=TradeSiteProject;integrated security=true;" +
                "TrustServerCertificate=True;");
        }

        public DbSet<Comment> UserComments { get; set; }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionstring);
    }
}
