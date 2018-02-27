using System;
using System.Collections.Generic;

namespace SchoolStore.Models
{
    public partial class Size
    {
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
