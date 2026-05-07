using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Cargo_EntityLayer.Concrete;

namespace Trade_Site_Cargo_DataAccessLayer.Context
{
    public class CargoContext : DbContext
    {
        public CargoContext(DbContextOptions<CargoContext> options) : base(options)
        {

        }


        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoStatus> CargoStatuses { get; set; }
        public DbSet<CargoCab> CargoCabs { get; set; }
        public DbSet<CargoOwner> CargoOwners { get; set; }
    }
}
