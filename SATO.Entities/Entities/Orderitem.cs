using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SATO.Entities.Entities
{
    public partial class Orderitem
    {
        [Key]
        public int OrderItemsId { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public decimal? Quantity { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}
