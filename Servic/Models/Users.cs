using System.ComponentModel.DataAnnotations;

namespace Servic.Models
{
    public class Users
    {

        [Key]
        public int UserID { get; set; }
        public string UserFIO { get; set; } 
        public string Phone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }
    }
}
