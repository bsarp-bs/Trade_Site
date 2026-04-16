using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Cargo_BusinessLayer.Services;
using Trade_Site_Cargo_DataAccessLayer.Abstract.Seperate;
using Trade_Site_Cargo_EntityLayer.Concrete;

namespace Trade_Site_Cargo_BusinessLayer.Managers
{
    public class CargoCabManager : ICargoCabService
    {
        private readonly ICargoCabDAL _cargoCabDAL;

        public CargoCabManager(ICargoCabDAL cargoCabService)
        {
            _cargoCabDAL = cargoCabService;
        }

        public void CreateBL(CargoCab entity)
        {
            _cargoCabDAL.CreateGenericT(entity);
        }

        public void DeleteBL(CargoCab entity)
        {
            _cargoCabDAL.DeleteGenericT(entity);
        }

        public List<CargoCab> GetAllBL()
        {
           return _cargoCabDAL.GetAllGenericT();
        }

        public CargoCab GetByIdBL(int id)
        {
            return _cargoCabDAL.GetByIdGenericT(id);
        }

        public void UpdateBL(CargoCab entity)
        {
            _cargoCabDAL.UpdateGenericT(entity);
        }
    }
}
