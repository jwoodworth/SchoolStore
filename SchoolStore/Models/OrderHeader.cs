using System;
using System.Collections.Generic;

namespace SchoolStore.Models
{
    public partial class OrderHeader
    {

        public OrderHeader()
        {
            OrderLineItems = new HashSet<OrderLineItem>();
        }
        
       
        public int ID { get; set; }                   
        public Guid TrackingNumber {get; set;}
        public DateTime? OrderDate { get; set; }
        public int? BillToAddressId { get; set; }
        public int? ShipToAddressId { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? ShipCost { get; set; }
        public decimal? TotalDue { get; set; }
        public DateTime? DateLastModified { get; set; }

        public ApplicationUser User { get; set; }
        public ICollection<OrderLineItem> OrderLineItems { get; set; }

    }
}
