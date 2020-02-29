using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoiceasy.Entity
{
    public class DealerEntity : IEntity
    {
        public string Id { get; set; }
        public string Sl { get; set; }
        public string DealerName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Code { get; set; }
        public string Date { get; set; }
        public DateTime Created_On { get; set; }
        public DateTime Modified_On { get; set; }
        //public int Sl { get; set; }
        //public string DealerName { get; set; }
        //public string Address { get; set; }
        //public string Contact { get; set; }
        //public string Code { get; set; }
        //public DateTime Date { get; set; }
    }
}
