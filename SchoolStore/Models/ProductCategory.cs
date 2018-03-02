using System;
using System.Collections.Generic;

namespace SchoolStore.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Products>();
        }
        public int ID { get; set; }
        public int ParentProductCategory { get; set; }
        public string Name { get; set; }
        public string CategoryImage { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
