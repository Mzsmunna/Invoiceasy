﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoiceasy.Entity
{
    public class ProductEntity : IEntity
    {
        public int Sl { get; set; }
        public string Category { get; set; }
        public string ProductCode { get; set; }
        public string ItemDescription { get; set; }
        public int UnitPrice { get; set; }
        public int StockAvailable { get; set; }
    }
}
