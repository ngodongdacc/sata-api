using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Application.Common.Model.Product
{
    public class FilterProductModel: FilterRequestBaseModel
    {
        public int CategoryID { get; set; }
        public int ProviderID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool isExport { get; set; }
    }
}
