using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolStore.Models
{
       public partial class CustomerAddress
       {
            public int ID { get; set; }
            public int AddressId { get; set; }
            public string AddressType { get; set; }
            public DateTime? DateLastModified { get; set; }

            public Address Address { get; set; }
            public ApplicationUser User { get; set; }

            //Reviewed and good for new SchoolStore
       }
}