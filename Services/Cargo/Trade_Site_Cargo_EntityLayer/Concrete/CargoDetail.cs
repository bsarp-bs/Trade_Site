using System;
using System.Collections.Generic;
using System.Text;

namespace Trade_Site_Cargo_EntityLayer.Concrete
{
    public class CargoDetail
    {
        public int CargoDetailID { get; set; }
        public string SenderCustomer { get; set; }
        public string RecevicerCustomer { get; set; }
        public int CargoDetailBarcode { get; set; }
        public int CargoCabID { get; set; }
        public CargoCab CargoCab { get; set; }



    }
}
