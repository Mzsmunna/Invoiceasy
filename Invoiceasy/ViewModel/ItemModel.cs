using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoiceasy.ViewModel
{
    public class ItemModel
    {
        public string SerialNo { get; set; }
        public string ProductDescriptions { get; set; }
        public int Quantity { get; set; }
        //Ignore for Challan
        public int UnitPrice { get; set; }
        //Ignore for Challan
        public int TotalAmount { get; set; }
        //Ignore for Invoice
        public string Unit { get; set; }

    }
}
