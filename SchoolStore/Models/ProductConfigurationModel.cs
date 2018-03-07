using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
/// <summary>
/// Must be old do not use
/// </summary>
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
        


    }
}
