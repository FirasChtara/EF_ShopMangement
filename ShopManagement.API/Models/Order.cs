using System;
using System.Collections.Generic;

namespace ShopManagement.API.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
            PaymentCustomers = new HashSet<PaymentCustomer>();
        }

        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual ICollection<PaymentCustomer> PaymentCustomers { get; set; }
    }
}
