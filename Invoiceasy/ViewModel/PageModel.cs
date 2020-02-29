using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoiceasy.ViewModel
{
    public class PageModel
    {
        public string Id { get; set; }
        public string PageName { get; set; }
        public string No { get; set; }
        public DealerModel Dealer { get; set; }
        public string Date { get; set; }
        public string Note { get; set; }
        public int ItemCount { get; set; } = 1;
        public List<ItemModel> AllProducts { get; set; }
        public string FileName { get; set; }
        public string FileLocation { get; set; }
        public string FullPath { get; set; }
        public string CurrentLogFile { get; set; }
        public string PreviousLogFile { get; set; }
        public SalesAndCollectionModel sale { get; set; }

        public PageModel()
        {
            AllProducts = new List<ItemModel>();
            Id = Guid.NewGuid().ToString("N");
        }
    }
}
