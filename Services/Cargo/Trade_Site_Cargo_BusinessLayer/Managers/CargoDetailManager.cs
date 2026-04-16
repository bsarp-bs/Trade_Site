using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Cargo_BusinessLayer.Services;
using Trade_Site_Cargo_DataAccessLayer.Abstract.Seperate;
using Trade_Site_Cargo_EntityLayer.Concrete;

namespace Trade_Site_Cargo_BusinessLayer.Managers
{
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDAL _cargoDetailDAL;

        public CargoDetailManager(ICargoDetailDAL cargoDetailDAL)
        {
            _cargoDetailDAL = cargoDetailDAL;
        }

        public void CreateBL(CargoDetail entity)
        {
            _cargoDetailDAL.CreateGenericT(entity);
        }

        public void DeleteBL(CargoDetail entity)
        {
            _cargoDetailDAL.DeleteGenericT(entity);
        }

        public List<CargoDetail> GetAllBL()
        {
            return _cargoDetailDAL.GetAllGenericT();
        }

        public CargoDetail GetByIdBL(int id)
        {
            return _cargoDetailDAL.GetByIdGenericT(id);
        }

        public void UpdateBL(CargoDetail entity)
        {
            _cargoDetailDAL.UpdateGenericT(entity);
        }
    }
}
