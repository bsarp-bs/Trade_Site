using System;
using System.Collections.Generic;
using System.Text;

namespace Trade_Site_Cargo_DtoLayer.DTOs.CargoDetailDTOs
{
    public class GetListCargoDetailDto
    {
        public int CargoDetailID { get; set; }
        public string SenderCustomer { get; set; }
        public string RecevicerCustomer { get; set; }
        public int CargoDetailBarcode { get; set; }
        public int CargoCabID { get; set; }

    }
}
