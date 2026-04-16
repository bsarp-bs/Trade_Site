using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Cargo_DataAccessLayer.Abstract.Generic;
using Trade_Site_Cargo_DataAccessLayer.EntityFramework.Generic;

namespace Trade_Site_Cargo_BusinessLayer.Services
{
    public interface IGenericService<S> where S : class
    {
       void DeleteBL(S entity);

       void UpdateBL(S entity);

       void CreateBL(S entity);

       List<S> GetAllBL();

       S GetByIdBL(int id);
    }
}
