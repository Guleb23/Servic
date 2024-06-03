using System.ComponentModel.DataAnnotations;

namespace Servic.Models
{
    public class Comments
    {
        [Key]
        public int commentID { get; set; }
        public string message { get; set; }
        public int masterID { get; set; }
        public int applicationID { get; set; }
    }
}
