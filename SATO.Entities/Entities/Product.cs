using System;
using System.Collections.Generic;

namespace SATO.Entities.Entities
{
    public partial class Product
    {
        public Product()
        {
            Orderitems = new HashSet<Orderitem>();
        }

        public int ProductId { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public int? ProviderId { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Provider? Provider { get; set; }
        public virtual ICollection<Orderitem> Orderitems { get; set; }
    }
}
