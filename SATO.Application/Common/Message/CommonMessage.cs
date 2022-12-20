using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Application.Common.Message
{
    partial class Message
    {
        public class CommonMessage
        {
            public static string NotEmpty => "Data is not be null";
            public static string NotExist => "Data is not Exist";
            public static string Success => "Success";
        }
    }
}
