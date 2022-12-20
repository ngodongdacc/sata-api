using System;
using System.Collections.Generic;

namespace SATO.Entities.Entities
{
    public partial class Order
    {
        public Order()
        {
            Orderitems = new HashSet<Orderitem>();
        }

        public int OrderId { get; set; }
        public string? OrderCode { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ShippedDate { get; set; }
        public string? ShipName { get; set; }
        public DateTime? ShipAddress { get; set; }
        public string? Description { get; set; }
        public int? OrderTypeId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual Ordertype? EmployeeNavigation { get; set; }
        public virtual ICollection<Orderitem> Orderitems { get; set; }
    }
}
