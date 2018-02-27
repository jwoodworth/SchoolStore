using System;
using System.Collections.Generic;

namespace SchoolStore.Models
{
    public partial class OrderHeader
    {
        public int SalesOrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public int? BillToAddressId { get; set; }
        public int? ShipToAddressId { get; set; }
        public string ShipToMethod { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? ShipCost { get; set; }
        public decimal? TotalDue { get; set; }
        public string CreditCardapprovalCode { get; set; }
        public string Comment { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
