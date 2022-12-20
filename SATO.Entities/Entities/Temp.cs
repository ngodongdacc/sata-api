using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Entities.Entities
{
    public class Temp
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string AreaId { get; set; }
        public DateTime? AccessTime { get; set; }
    }
}
