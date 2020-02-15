using System.ComponentModel.DataAnnotations;

namespace TelephoneBook.Models
{
    public class Admin
    {
        [Key]
        public int id { get; set; }
        public string nick { get; set; }
        public string password { get; set; }
    }
}
