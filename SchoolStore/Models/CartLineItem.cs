using System;
using System.Collections.Generic;

namespace SchoolStore.Models
{
    public partial class CartLineItem
    {
        public int CartId { get; set; }
        public int LineItemId { get; set; }
        public int? ProductId { get; set; }
        public int? ProductConfigId { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? LineItemTotal { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
