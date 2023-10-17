using System.ComponentModel.DataAnnotations;

namespace Models.LoggerRelated.LoggerRelated
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
