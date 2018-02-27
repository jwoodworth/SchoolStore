using System;
using System.Collections.Generic;

namespace SchoolStore.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int? SalesOrderId { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentCardType { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
