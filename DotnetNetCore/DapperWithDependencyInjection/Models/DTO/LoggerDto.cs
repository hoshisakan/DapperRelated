using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class LoggerDto
    {
        [Required]
        public string Message { get; set; }
        public string? ClassName { get; set; }
        public string? MethodName { get; set; }
        public Exception? Exception { get; set; }
        [Required]
        public string LogLevel { get; set; }
    }
}
