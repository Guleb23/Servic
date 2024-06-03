using System.ComponentModel.DataAnnotations;

namespace Servic.Models
{
    public class Type
    {
        [Key]
        public int TypeID { get; set; }
        public string Name { get; set; }
    }
}
