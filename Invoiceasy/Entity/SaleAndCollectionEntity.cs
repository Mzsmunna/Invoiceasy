using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoiceasy.Entity
{
    public class SaleAndCollectionEntity
    {
        public string Id { get; set; }
        public string Sl { get; set; }
        public DateTime? Date { get; set; }
        public string DealerName { get; set; }
        public string DealerCode { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string IC_NO { get; set; }
        public string MR_NO { get; set; }
        public int? OpeningBalance { get; set; }
        public int SalesAmount { get; set; }
        public int CollectionAmount { get; set; }
        public int? ClosingBalance { get; set; }
        public string Remarks { get; set; }
        public string SyncType { get; set; }
        public DateTime Created_On { get; set; }
        public DateTime Modified_On { get; set; }
    }
}
