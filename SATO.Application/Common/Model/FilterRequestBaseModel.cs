using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Application.Common.Model
{
    public class FilterRequestBaseModel
    {
        public string Search { get; set; }

        public int Offset { get; set; } = 0;

        public int Limit { get; set; } = -1;
    }
}
