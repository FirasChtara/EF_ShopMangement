using System;
using System.Collections.Generic;

namespace ShopManagement.API.Models
{
    public partial class PaymentCustomer
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? PaymentTypeId { get; set; }
        public int? SettlementAmount { get; set; }

        public virtual Order? Order { get; set; }
        public virtual PaymentType? PaymentType { get; set; }
    }
}
