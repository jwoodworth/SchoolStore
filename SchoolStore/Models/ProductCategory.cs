using System;
using System.Collections.Generic;

namespace SchoolStore.Models
{
    public partial class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public int ParentProductCategory { get; set; }
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
