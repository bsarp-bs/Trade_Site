using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Cargo_DataAccessLayer.Abstract.Generic;
using Trade_Site_Cargo_EntityLayer.Concrete;

namespace Trade_Site_Cargo_DataAccessLayer.Abstract.Seperate
{
    public interface ICargoStatusDAL : IGenericRepoDAL<CargoStatus>
    {
    }
}
