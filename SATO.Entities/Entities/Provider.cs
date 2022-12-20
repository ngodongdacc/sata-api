using System;
using System.Collections.Generic;

namespace SATO.Entities.Entities
{
    public partial class Provider
    {
        public Provider()
        {
            Products = new HashSet<Product>();
        }

        public int ProviderId { get; set; }
        public string? ProviderCode { get; set; }
        public string? ProviderName { get; set; }
        public string? Address { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? ProviderPhone { get; set; }
        public string? ProviderEmail { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
