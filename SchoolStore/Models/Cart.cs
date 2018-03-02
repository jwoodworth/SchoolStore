using System;
using System.Collections.Generic;

namespace SchoolStore.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartLineItems = new HashSet<CartLineItem>();
        }

        public int ID { get; set; }
        public Guid TrackingNumber { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }

        public ICollection<CartLineItem> CartLineItems { get; set; }
    }
}
