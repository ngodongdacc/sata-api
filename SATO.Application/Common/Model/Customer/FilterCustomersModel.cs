using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Application.Common.Model.Customer
{
    public class FilterCustomersModel : FilterRequestBaseModel
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool isExport { get; set; }
    }
}
