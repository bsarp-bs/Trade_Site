using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Cargo_DataAccessLayer.Abstract.Seperate;
using Trade_Site_Cargo_DataAccessLayer.Context;
using Trade_Site_Cargo_DataAccessLayer.EntityFramework.Generic;
using Trade_Site_Cargo_EntityLayer.Concrete;

namespace Trade_Site_Cargo_DataAccessLayer.EntityFramework.Separate
{
    public class EFCargoOwnerDAL : EFGenericRepoDAL<CargoOwner>, ICargoOwnerDAL
    {
        public EFCargoOwnerDAL(CargoContext cargoContext) : base(cargoContext)
        {
        }
    }
}
