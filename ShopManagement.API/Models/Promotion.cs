using System;
using System.Collections.Generic;

namespace ShopManagement.API.Models
{
    public partial class Promotion
    {
        public Promotion()
        {
            PromotionProducts = new HashSet<PromotionProduct>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<PromotionProduct> PromotionProducts { get; set; }
    }
}
