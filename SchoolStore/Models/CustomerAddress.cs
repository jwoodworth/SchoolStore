using System;
using System.Collections.Generic;

namespace SchoolStore.Models
{
    public partial class CustomerAddress
    {
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public string AddressType { get; set; }
        public DateTime? DateLastModified { get; set; }

        public Address Address { get; set; }
        public Customer Customer { get; set; }
    }
}
