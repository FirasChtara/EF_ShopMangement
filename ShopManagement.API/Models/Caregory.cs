using System;
using System.Collections.Generic;

namespace ShopManagement.API.Models
{
    public partial class Caregory
    {
        public Caregory()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
