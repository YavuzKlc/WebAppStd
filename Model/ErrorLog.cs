using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class ErrorLog : BaseEntity
    {
        [StringLength(255)]
        public string MethodName { get; set; }

        public string ErrorMessage { get; set; }

        public string StackTrace { get; set; }

        public string Detail { get; set; }

        [StringLength(255)]
        public string Source { get; set; }
    }
}