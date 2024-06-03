using System.ComponentModel.DataAnnotations;

namespace Servic.Models
{
    public class Application
    {
        [Key]
        public int RequestId { get; set; }
        public DateOnly startDate { get; set; }
        public string climateTechType { get; set; }
        public string climateTechModel { get; set; }
        public string proplemDescryption { get; set; }
        public int applicationStatus { get; set; }
        public DateOnly? completionDate { get; set; }
        public string? repairParts { get; set; }
        public int? masterID { get; set; }
        public int? clientID { get; set; }
    }
}
