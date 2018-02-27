using System;
using System.Collections.Generic;

namespace SchoolStore.Models
{
    public partial class Shipping
    {
        public int ShippingId { get; set; }
        public int? SalesOrderId { get; set; }
        public string Shipper { get; set; }
        public DateTime? ShipDate { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
