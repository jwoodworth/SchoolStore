using System;
using System.Collections.Generic;

namespace SchoolStore.Models
{
    public partial class Products
    {
        public Products()
        {
            Reviews = new HashSet<Review>();
            CartLineItems = new HashSet<CartLineItem>();
            Configurations = new HashSet<ProductConfiguration>();
            OrderLineItems = new HashSet<OrderLineItem>();
        }

        public int ID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal? UnitPrice { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
        public ProductCategory Category { get; set;}
        public string ImageURL { get; set; }
            
        //A product can have many reviews
        public ICollection<Review> Reviews { get; set; }

        public ICollection<OrderLineItem> OrderLineItems { get; set; }
        public ICollection<ProductConfiguration> Configurations { get; set; }
        public ICollection<CartLineItem> CartLineItems { get; set; }

       
    }
}
