using System;
using System.Collections.Generic;

namespace ShopManagement.API.Models
{
    public partial class OrderProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int? Price { get; set; }
        public DateTime CreationDate { get; set; }
        public int Quantity { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
