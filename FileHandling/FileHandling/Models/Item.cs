using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileHandling.Models
{
    public class Item
    {
        public int id { get; set; }
      
        public string item_name { get; set; }
        public Decimal item_quantity { get; set; }
        public Decimal item_amount { get; set; }
        public Decimal item_discount { get; set; }
        public Decimal item_rate { get; set; }

    }
}
