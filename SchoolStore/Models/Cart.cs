using System;
using System.Collections.Generic;

namespace SchoolStore.Models
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public string CookieId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
