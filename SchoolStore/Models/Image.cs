using System;
using System.Collections.Generic;

namespace SchoolStore.Models
{
    public partial class Image
    {
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
        public string ImageAltText { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
