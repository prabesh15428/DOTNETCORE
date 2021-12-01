using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelFileHandling.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public Decimal ItemRate { get; set; }
        public Decimal ItemQuantity { get; set; }
        public Decimal Discount { get; set; }
        public Decimal Amount { get; set; }

        
    }
}
