using System;
using System.Collections.Generic;

namespace ShopManagement.API.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
            PromotionProducts = new HashSet<PromotionProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? CategoryId { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Caregory? Category { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual ICollection<PromotionProduct> PromotionProducts { get; set; }
    }
}
