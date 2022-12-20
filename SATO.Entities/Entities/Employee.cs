using System;
using System.Collections.Generic;

namespace SATO.Entities.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Orders = new HashSet<Order>();
        }

        public int EmployeeId { get; set; }
        public string? EmployeeCode { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime? BirthOfDate { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Description { get; set; }
        public string? UpdatedDate { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
