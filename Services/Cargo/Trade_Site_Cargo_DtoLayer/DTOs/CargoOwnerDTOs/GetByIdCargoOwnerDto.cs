using System;
using System.Collections.Generic;
using System.Text;

namespace Trade_Site_Cargo_DtoLayer.DTOs.CargoOwnerDTOs
{
    public class GetByIdCargoOwnerDto
    {
        public int CargoOwnerID { get; set; }
        public string CargoOwnerName { get; set; }
        public string CargoOwnerSurname { get; set; }
        public string CargoOwnerEmail { get; set; }
        public string CargoOwnerPhone { get; set; }
        public string CargoOwnerDistrinct { get; set; }
        public string CargoOwnerCity { get; set; }
        public string CargoOwnerAddress { get; set; }
    }
}
