using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Servic.Models
{
    public class Application
    {
        [Key]
        public int RequestId { get; set; }
        public DateOnly startDate { get; set; }
        public string carType { get; set; }
        public string carModel { get; set; }
        public string proplemDescryption { get; set; }

        public string? applicationStatus { get; set; }
        public DateOnly? completionDate { get; set; }
        public string? repairParts { get; set; }
        public int? masterID { get; set; }
        public int? clientID { get; set; }
    }
}
