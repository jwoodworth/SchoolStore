using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolStore.Models
{
    public class ProductsViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductSize { get; set; }
        public string ProductColor { get; set;}
        public decimal Price { get; set; }
        public string ProductDescription { get; set; }
        public string ImageUrl { get; set; }
    }
}
