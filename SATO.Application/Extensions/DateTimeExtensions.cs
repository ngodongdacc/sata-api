using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Application.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime StartTime(this DateTime dateTime)
        {
            return new(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
        }
        public static DateTime EndTime(this DateTime dateTime)
        {
            return new(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59);
        }
    }
}
