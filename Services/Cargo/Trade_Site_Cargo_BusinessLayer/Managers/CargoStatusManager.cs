using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Cargo_BusinessLayer.Services;
using Trade_Site_Cargo_DataAccessLayer.Abstract.Seperate;
using Trade_Site_Cargo_EntityLayer.Concrete;

namespace Trade_Site_Cargo_BusinessLayer.Managers
{
    public class CargoStatusManager : ICargoStatusService
    {
        private readonly ICargoStatusDAL _cargoStatusDAL;

        public CargoStatusManager(ICargoStatusDAL cargoStatusDAL)
        {
            _cargoStatusDAL = cargoStatusDAL;
        }

        public void CreateBL(CargoStatus entity)
        {
            _cargoStatusDAL.CreateGenericT(entity);
        }

        public void DeleteBL(CargoStatus entity)
        {
            _cargoStatusDAL.DeleteGenericT(entity);
        }

        public List<CargoStatus> GetAllBL()
        {
            return _cargoStatusDAL.GetAllGenericT();
        }

        public CargoStatus GetByIdBL(int id)
        {
            return _cargoStatusDAL.GetByIdGenericT(id);
        }

        public void UpdateBL(CargoStatus entity)
        {
            _cargoStatusDAL.UpdateGenericT(entity);
        }
    }
}
