using System;
using System.Collections.Generic;

namespace SchoolStore.Models
{
    public partial class Address
    {
        public Address()
        {
            CustomerAddress = new HashSet<CustomerAddress>();
        }

        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }

        public ICollection<CustomerAddress> CustomerAddress { get; set; }

        //Reviewed and good for SchoolStore v2
    }
}
