using System;
using System.Collections.Generic;
using System.Text;

namespace Trade_Site_Cargo_DataAccessLayer.Abstract.Generic
{
    public interface IGenericRepoDAL<T> where T : class
    {
        void CreateGenericT(T entity);

        void DeleteGenericT(T entity);

        void UpdateGenericT(T entity);

        List<T> GetAllGenericT();  

        T GetByIdGenericT(int id);
    }
}
