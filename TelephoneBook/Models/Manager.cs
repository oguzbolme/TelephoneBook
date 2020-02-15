using System.ComponentModel.DataAnnotations;

namespace TelephoneBook.Models
{
    public class Manager
    {
        [Key]
        public int id { get; set; }
        public int employeeID { get; set; }
    }
}
