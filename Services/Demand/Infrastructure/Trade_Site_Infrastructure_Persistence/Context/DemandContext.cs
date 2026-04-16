using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Demand_Domain;

namespace Trade_Site_Infrastructure_Persistence.Context
{
    public class DemandContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1440;Database=TradeSite_Project;User Id=sa;Password=1234567Ka*;TrustServerCertificate=True;");
        }


        public DbSet<OrderAdress> OrderAdressc { get; set; }
        public DbSet<OrderDetail> OrderDetailc { get; set; }
        public DbSet<OrderMain> OrderMainc { get; set; }
    }
}
