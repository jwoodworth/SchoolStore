using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolStore.Models
{
    public class ProductConfiguration
    {

        public int ID { get; set; }
        public int ColorID { get; set; }
        public int SizeID { get; set; }
        public int Inventory { get; set; }
        public decimal PriceSurcharge { get; set; }

        public Size Size { get; set; }
        public Color Color { get; set; }
        public Products Product { get; set; }
    }
}
