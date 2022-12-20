using System;
using System.Collections.Generic;

namespace SATO.Entities.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string? ContactName { get; set; }
        public string? ContactPhone { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
