using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataModel.ExceptionRelated
{
    public class ExceptionDetails
    {
        public string Message { get; set; } = default!;
        public string Details { get; set; } = default!;
        //public string StackTrace { get; set; } = default!;
        //public string Source { get; set; } = default!;
        //public string ClassName { get; set; } = default!;
        //public string Method { get; set; } = default!;
        //public string InnerException { get; set; } = default!;
    }
}
