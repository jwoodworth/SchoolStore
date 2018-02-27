using System;
using System.Collections.Generic;

namespace SchoolStore.Models
{
    public partial class Cookie
    {
        public int CookieId { get; set; }
        public string CookieString { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
