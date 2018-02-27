using System;
using System.Collections.Generic;

namespace SchoolStore.Models
{
    public partial class ProductConfig
    {
        public int ProductConfigId { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
