using System;
using System.Collections.Generic;

namespace ShopManagement.API.Models
{
    public partial class PromotionProduct
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? PromotionId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? TauxPercentage { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Promotion? Promotion { get; set; }
    }
}
