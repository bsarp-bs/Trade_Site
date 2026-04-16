using System;
using System.Collections.Generic;
using System.Text;

namespace Trade_Site_Cargo_EntityLayer.Concrete
{
    public class CargoStatus
    {
        public int CargoStatusID { get; set; }
        public string Barcode { get; set; }
        public string Desc { get; set; }
        public DateTime StatusDate { get; set; }
    }
}
    