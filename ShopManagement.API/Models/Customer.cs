using System;
using System.Collections.Generic;

namespace ShopManagement.API.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? Nom { get; set; }
        public string Email { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? TypeId { get; set; }

        public virtual Type? Type { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
