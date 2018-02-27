using System;
using System.Collections.Generic;

namespace SchoolStore.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int? ReviewId { get; set; }
        public int? ProductCategoryId { get; set; }
        public int? ImageId { get; set; }
        public decimal? UnitPrice { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
