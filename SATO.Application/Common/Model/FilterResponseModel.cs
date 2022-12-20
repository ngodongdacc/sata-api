using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Application.Common.Model
{
    public class FilterResponseModel<T>
    {
        public int Total { get; set; } = 0;

        public T Data { get; set; }
    }
}
