using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Application.Common
{
    public class ResultModel
    {
        public int CustomerID { get; set; }
        
        public InDetail InDetail { get; set; }
        public OutDetail OutDetail { get; set; }
        public string CardNo { get; set; }
    }
    public class InDetail
    {
        public int CheckInTime { get; set; }
        public string AereaId { get; set; }
    }
    public class OutDetail
    {
        public int CheckOutTime { get; set; }
        public string AereaId { get; set; }
    }
}
