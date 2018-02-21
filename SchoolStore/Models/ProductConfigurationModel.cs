using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SchoolStore.Models
{
    public class ProductConfigurationModel
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string ProductName { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string ProductColor { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string ProductSize { get; set; }
        //add more stuff
    }
}
