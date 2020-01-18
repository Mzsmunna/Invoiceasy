using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoiceasy.ViewModel
{
    public class PageModel
    {
        public string PageName { get; set; }
        public string No { get; set; }
        //public string To { get; set; }
        //public string Contact { get; set; }
        //public string Address { get; set; }
        //public string Code { get; set; }
        public DealerModel Dealer { get; set; }
        public string Date { get; set; }
        public string Note { get; set; }
        public int ItemCount { get; set; } = 1;
        public List<ItemModel> AllProducts { get; set; }

        public PageModel()
        {
            AllProducts = new List<ItemModel>();
            //ItemCount = 1;
        }
    }
}
