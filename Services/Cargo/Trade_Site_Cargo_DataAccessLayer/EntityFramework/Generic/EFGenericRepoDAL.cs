using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Cargo_DataAccessLayer.Abstract.Generic;
using Trade_Site_Cargo_DataAccessLayer.Context;

namespace Trade_Site_Cargo_DataAccessLayer.EntityFramework.Generic
{
    public class EFGenericRepoDAL<T> : IGenericRepoDAL<T> where T : class
    {
        private readonly CargoContext _cargoContext;

        public EFGenericRepoDAL(CargoContext cargoContext)
        {
            _cargoContext = cargoContext;
        }

        public void CreateGenericT(T entity)
        {
            _cargoContext.Set<T>().Add(entity);
            _cargoContext.SaveChanges();
        }

        public void DeleteGenericT(T entity)
        {
            _cargoContext.Set<T>().Remove(entity);
            _cargoContext.SaveChanges();
        }

        public List<T> GetAllGenericT()
        {
            var value =  _cargoContext.Set<T>().ToList();
            return value;
        }

        public T GetByIdGenericT(int id)
        {
            var value =  _cargoContext.Set<T>().Find(id);
            return value;
        }

        public void UpdateGenericT(T entity)
        {
            _cargoContext.Set<T>().Update(entity);
            _cargoContext.SaveChanges();
        }
    }
}
