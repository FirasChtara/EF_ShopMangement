using System;
using System.Collections.Generic;

namespace ShopManagement.API.Models
{
    public partial class Type
    {
        public Type()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
