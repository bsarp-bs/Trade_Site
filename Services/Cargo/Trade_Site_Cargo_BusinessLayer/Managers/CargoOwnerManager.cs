using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Cargo_BusinessLayer.Services;
using Trade_Site_Cargo_DataAccessLayer.Abstract.Seperate;
using Trade_Site_Cargo_EntityLayer.Concrete;

namespace Trade_Site_Cargo_BusinessLayer.Managers
{
    public class CargoOwnerManager : ICargoOwnerService
    {
        private readonly ICargoOwnerDAL _cargoOwnerDAL;

        public CargoOwnerManager(ICargoOwnerDAL cargoOwnerDAL)
        {
            _cargoOwnerDAL = cargoOwnerDAL;
        }

        public void CreateBL(CargoOwner entity)
        {
            _cargoOwnerDAL.CreateGenericT(entity);
        }

        public void DeleteBL(CargoOwner entity)
        {
            _cargoOwnerDAL.DeleteGenericT(entity);
        }

        public List<CargoOwner> GetAllBL()
        {
            return _cargoOwnerDAL.GetAllGenericT();
        }

        public CargoOwner GetByIdBL(int id)
        {
            return _cargoOwnerDAL.GetByIdGenericT(id);
        }

        public void UpdateBL(CargoOwner entity)
        {
            _cargoOwnerDAL.UpdateGenericT(entity);
        }
    }
}
