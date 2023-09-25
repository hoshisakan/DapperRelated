using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataModel.ExceptionRelated
{
    public class ExceptionDetails
    {
        public string Message { get; set; } = string.Empty;
        public string StackTrace { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public string Method { get; set; } = string.Empty;
        public string InnerException { get; set; } = string.Empty;
    }
}
