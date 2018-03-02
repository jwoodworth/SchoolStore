using System;
using System.Collections.Generic;

namespace SchoolStore.Models
{
    public partial class Color
    {
        public Color()
        {
            Configurations = new HashSet<ProductConfiguration>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }

        public ICollection<ProductConfiguration> Configurations { get; set; }
    }
}
