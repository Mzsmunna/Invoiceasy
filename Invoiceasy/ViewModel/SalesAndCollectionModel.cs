using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoiceasy.ViewModel
{
    public class SalesAndCollectionModel
    {
        public string Id { get; set; }

        [DisplayName("Serial No")]
        public string Sl { get; set; }
        public DateTime? Date { get; set; }

        [DisplayName("Client Name")]
        public string DealerName { get; set; }

        [DisplayName("Dealer Code")]
        public string DealerCode { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }

        [DisplayName("Challan No / Invoice No")]
        public string IC_NO { get; set; }

        [DisplayName("MR.NO")]
        public string MR_NO { get; set; }

        [DisplayName("Opening Balance")]
        public int? OpeningBalance { get; set; }

        [DisplayName("Sales Amount")]
        public int SalesAmount { get; set; }

        [DisplayName("Collection Amount")]
        public int CollectionAmount { get; set; }

        [DisplayName("Closing Balance")]
        public int? ClosingBalance { get; set; }
        public string Remarks { get; set; }
        public string SyncType { get; set; }
    }

    public sealed class SalesAndCollectionModelMap : ClassMap<SalesAndCollectionModel>
    {
        public SalesAndCollectionModelMap()
        {
            Map(m => m.Id).Name("Id", "id", "ID");
            Map(m => m.Sl).Name("Sl", "SL", "sl");
            Map(m => m.Date).Name("Date", "date");
            Map(m => m.DealerName).Name("ClientName", "Client Name", "client name", "DealerName", "Dealer Name", "dealer name");
            Map(m => m.DealerCode).Name("ClientCode", "Client Code", "client code", "DealerCode", "Dealer Code", "dealer code");
            Map(m => m.Address).Name("Address", "address");
            Map(m => m.Contact).Name("Contact", "contact");
            Map(m => m.IC_NO).Name("IC_NO", "IC NO", "ic_no", "ic no", "Invoice_Challan_No", "invoice_challan_no");
            Map(m => m.MR_NO).Name("MR_NO", "MR NO", "mr no", "MR.NO", "mr.no");
            Map(m => m.OpeningBalance).Name("OpeningBalance", "Opening Balance", "opening balance");
            Map(m => m.SalesAmount).Name("SalesAmount", "Sales Amount", "sales amount");
            Map(m => m.CollectionAmount).Name("CollectionAmount", "Collection Amount", "collection amount");
            Map(m => m.ClosingBalance).Name("ClosingBalance", "Closing Balance", "closing balance");
            Map(m => m.Remarks).Name("Remarks", "remarks", "remark", "Remark");
            Map(m => m.SyncType).Name("SyncType", "Sync Type", "sync type");            
        }
    }
}
