using System;
using System.Collections.Generic;

namespace SchoolStore.Models
{
    public partial class Color
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
