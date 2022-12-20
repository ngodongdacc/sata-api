using System;
using System.Collections.Generic;

namespace SATO.Entities.Entities
{
    public partial class Ordertype
    {
        public Ordertype()
        {
            Orders = new HashSet<Order>();
        }

        public int OrderTypeId { get; set; }
        public string? OrderTypeName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
