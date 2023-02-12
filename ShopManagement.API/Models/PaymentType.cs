using System;
using System.Collections.Generic;

namespace ShopManagement.API.Models
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            PaymentCustomers = new HashSet<PaymentCustomer>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<PaymentCustomer> PaymentCustomers { get; set; }
    }
}
