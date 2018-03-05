using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolStore.Models
{
    public class ShippingViewModel
    {
        public CartLineItem[] CartLineItem { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage ="Please enter your shipping address")]
        [System.ComponentModel.DataAnnotations.Display(Name = "Your Shipping Address")]
        public string Address { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string City { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string State { get; set; }

        public string ZipCode { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public DateTime? Date { get; set; }
    }
}
