using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoiceasy.ViewModel
{
    public class ProductModel
    {
        [DisplayName("Serial No")]
        public string Sl { get; set; }
        public string Category { get; set; }

        [DisplayName("Product Code")]
        public string ProductCode { get; set; }

        [DisplayName("Item Description")]
        public string ItemDescription { get; set; }

        [DisplayName("Unit Price")]
        public string UnitPrice { get; set; }

        [DisplayName("Stock Available")]
        public int StockAvailable { get; set; }
        public string Image { get; set; }
    }

    public sealed class ProductModelMap : ClassMap<ProductModel>
    {
        public ProductModelMap()
        {
            Map(m => m.Sl).Name("Sl", "SL", "sl", "id", "ID", "Id");
            Map(m => m.Category).Name("Category", "category");
            Map(m => m.ProductCode).Name("ProductCode", "Product Code", "product code");
            Map(m => m.ItemDescription).Name("ItemDescription", "Item Description", "item description");
            Map(m => m.UnitPrice).Name("UnitPrice", "Unit Price", "unit price");
            Map(m => m.StockAvailable).Name("StockAvailable", "Stock Available", "stock available", "Stock", "stock");
            Map(m => m.Image).Name("image", "Image", "images", "Images", "Pic", "pic");
            //Map(m => m.Id).Ignore();
        }
    }
}
