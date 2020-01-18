using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoiceasy.ViewModel
{
    public class ProductModel
    {
        public string Sl { get; set; }
        public string Category { get; set; }
        public string ProductCode { get; set; }
        public string ItemDescription { get; set; }
        public string UnitPrice { get; set; }
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
