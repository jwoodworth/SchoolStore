using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolStore.Models
{
    public class ShippingViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public CartLineItem[] CartLineItem { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter your shipping address")]
        [System.ComponentModel.DataAnnotations.Display(Name = "Your Shipping Address")]
        public string ShippingAddress { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string ShippingCity { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string ShippingState { get; set; }

        [Required]
        public string ShippingZipCode { get; set; }

        
        [CreditCard]
        public string CreditCardNumber { get; set; }
        
        public string CreditCardName { get; set; }

        public string CreditCardVerificationValue { get; set; }
        
        public string ExpirationMonth { get; set; }
        
        public string ExpirationYear { get; set; }

        
        public string BillingAddress { get; set; }
        
        public string BillingCity { get; set; }
        
        public string BillingState { get; set; }
        
        public string BillingZipCode { get; set; }

        public SavedCreditCard[] SavedCreditCards { get; set; }

        public string CardToken { get; set; }
    }

    public class SavedCreditCard
    { 
        public string LastFour { get; set; }
        public string Token { get; set; }
    }
}
