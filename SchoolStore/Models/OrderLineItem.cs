using System;
using System.Collections.Generic;

namespace SchoolStore.Models
{
    public partial class OrderLineItem
    {
        public OrderLineItem()
        {
            Configurations = new HashSet<ProductConfiguration>();
        }

        public int ID {get; set;}
        public int? Quantity { get; set; }
        public Products Product { get; set; }
        public OrderHeader OrderHeader { get; set; }
        
        public ICollection<ProductConfiguration> Configurations { get; set; }
    }
}
