using Invoiceasy.Helper;
using Invoiceasy.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoiceasy.Manager
{
    public static class ProductManager
    {
        private static List<ProductModel> ProductList { get; set; }
        private static readonly string productFilePath;

        static ProductManager()
        {
            productFilePath = @"\Libs\Files\CoreFiles\DataFiles\ProductList.txt";

            if (ProductList == null)
            {               
                ProductList = new List<ProductModel>();
                LoadAllProducts();
            }
        }

        public static List<ProductModel> LoadAllProducts()
        {
            ProductList = CsvHelperUtility.ReadDataFromFile<ProductModel, ProductModelMap>(productFilePath);
            return ProductList;
        }

        public static List<ProductModel> GetAllProducts()
        {
            return ProductList;
        }

        public static int GetAllProductsCount()
        {
            return ProductList.Count;
        }

        public static ProductModel SearchProduct(ProductModel product)
        {
            var findProduct = ProductList.Where(x => x.ProductCode.Equals(product.ProductCode)).FirstOrDefault();
            return findProduct;
        }

        public static List<ProductModel> SearchProducts(ProductModel product)
        {
            var findProductList = ProductList.Where(x => x.ProductCode.Equals(product.ProductCode)).ToList();
            return findProductList;
        }

        public static bool AddProduct(ProductModel product)
        {
            var productCodeExist = ProductList.Where(x => !(x.Sl.Equals(product.Sl)) && x.ProductCode.ToLower().Equals(product.ProductCode.ToLower())).FirstOrDefault();

            if(productCodeExist == null)
            {
                ProductList.Add(product);
                SaveChange();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static bool AddManyProduct(List<ProductModel> products)
        {
            ProductList.AddRange(products);
            SaveChange();
            return true;
        }

        private static void SaveChange()
        {
            ProductList.RemoveAll(item => item == null);
            CsvHelperUtility.WriteDataToFile<ProductModel>(false, productFilePath, ",", ProductList);
            LoadAllProducts();
        }

        public static bool UpdateProduct(ProductModel product)
        {
            var findProduct = ProductList.Where(x => x.ProductCode.Equals(product.ProductCode)).FirstOrDefault();

            var productCodeExist = ProductList.Where(x => !(x.Sl.Equals(product.Sl)) && x.ProductCode.ToLower().Equals(product.ProductCode.ToLower())).FirstOrDefault();

            if (findProduct != null && productCodeExist == null)
            {
                findProduct = product;
                SaveChange();
                return true;
            }
            else
            {
                return false;
            }           
        }

        public static bool UpdateAllProducts(List<ProductModel> products)
        {
            ProductList = products;
            SaveChange();
            return true;
        }

        public static bool DeleteProduct(ProductModel product)
        {
            var findProduct = ProductList.Where(x => x.ProductCode.Equals(product.ProductCode)).FirstOrDefault();

            if (findProduct != null)
            {
                ProductList.Remove(findProduct);
                SaveChange();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DeleteManyProducts(List<ProductModel> products)
        {
            foreach(var product in products)
            {
                var findProduct = ProductList.Where(x => x.ProductCode.Equals(product.ProductCode)).FirstOrDefault();

                if (findProduct != null)
                {
                    ProductList.Remove(findProduct);
                }
            }

            SaveChange();
            return true;
        }
    }
}
