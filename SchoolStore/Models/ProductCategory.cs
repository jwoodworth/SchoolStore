using System;
using System.Collections.Generic;

namespace SchoolStore.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Products>();
            ChildCategories = new HashSet<ProductCategory>();
        }
        public int ID { get; set; }
        public int? ParentProductCategoryId { get; set; }
        public string Name { get; set; }
        public string CategoryImage { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }

        public ICollection<Products> Products { get; set; }
        public ProductCategory ParentProductCategory { get; set; }
        public ICollection<ProductCategory> ChildCategories { get; set; }
    }
}
