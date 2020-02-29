using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoiceasy.ViewModel
{
    public class DealerModel
    {
        [DisplayName("Serial No")]
        public string Sl { get; set; }

        [DisplayName("Dealer Name")]
        public string DealerName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Code { get; set; }
        public string Date { get; set; }
    }

    public sealed class DealerModelMap : ClassMap<DealerModel>
    {
        public DealerModelMap()
        {
            Map(m => m.Sl).Name("Sl", "id", "ID", "SL", "Id", "sl");
            Map(m => m.DealerName).Name("DealerName", "Dealer Name", "dealer name");
            Map(m => m.Address).Name("Address", "address");
            Map(m => m.Contact).Name("Contact", "contact");
            Map(m => m.Code).Name("Code", "code");
            Map(m => m.Date).Name("Date", "date");
            //Map(m => m.Id).Ignore();
        }
    }
}
