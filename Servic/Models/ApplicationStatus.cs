using System.ComponentModel.DataAnnotations;

namespace Servic.Models
{
    public class ApplicationStatus
    {
        [Key]
        public int ApplicationID { get; set; }
        public string Name { get; set; }
    }
}
