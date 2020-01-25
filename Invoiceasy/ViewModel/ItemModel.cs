using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoiceasy.ViewModel
{
    public class ItemModel
    {
        [DisplayName("Serial No")]
        public string SerialNo { get; set; }
        [DisplayName("Product Descriptions")]
        public string ProductDescriptions { get; set; }
        //Ignore for Challan
        [DisplayName("Unit Price")]
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }       
        //Ignore for Challan
        [DisplayName("Total Amount")]
        public int TotalAmount { get; set; }
        //Ignore for Invoice
        public string Unit { get; set; }
        //Ignore for Both Invoice & Challan
        public string ProductCode { get; set; } //Id

    }
}
