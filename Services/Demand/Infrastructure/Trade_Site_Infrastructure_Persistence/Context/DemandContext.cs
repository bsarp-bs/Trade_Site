using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Demand_Domain;

namespace Trade_Site_Infrastructure_Persistence.Context
{
    public class DemandContext : DbContext
    {
        // Provider and connection string are configured by the host (Presentation/Program.cs).
        public DemandContext(DbContextOptions<DemandContext> options) : base(options)
        {
        }


        public DbSet<OrderAdress> OrderAdressc { get; set; }
        public DbSet<OrderDetail> OrderDetailc { get; set; }
        public DbSet<OrderMain> OrderMainc { get; set; }
    }
}
