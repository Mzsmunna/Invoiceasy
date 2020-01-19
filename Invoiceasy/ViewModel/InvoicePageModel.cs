using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoiceasy.ViewModel
{
    public class InvoicePageModel : PageModel
    {
        public string AmountInWord { get; set; }
        public int InTotalAmount { get; set; }
        public int Discount { get; set; } = 40; //%
        public int DiscountAmount { get; set; }
        public string SpecialDiscount { get; set; } = "Special Discount ";
        public int PayableAmount { get; set; }

    }
}
