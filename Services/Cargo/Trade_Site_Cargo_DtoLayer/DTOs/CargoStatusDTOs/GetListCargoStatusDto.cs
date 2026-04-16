using System;
using System.Collections.Generic;
using System.Text;

namespace Trade_Site_Cargo_DtoLayer.DTOs.CargoStatusDTOs
{
    public class GetListCargoStatusDto
    {
        public int CargoStatusID { get; set; }
        public string Barcode { get; set; }
        public string Desc { get; set; }
        public DateTime StatusDate { get; set; }
    }
}
