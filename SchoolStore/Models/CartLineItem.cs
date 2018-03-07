using System;
using System.Collections.Generic;

namespace SchoolStore.Models
{
    public partial class CartLineItem
    {

        public CartLineItem()
        {
        }


        public int ID { get; set; }
        public int Quantity { get; set; }
        public ProductConfiguration ProductConfiguration { get; set; }
        public Cart Cart { get; set; }
        
    }
}
