using System.ComponentModel.DataAnnotations;

namespace TelephoneBook.Models
{
    public class Contact
    {
        [Key]
        public int id { get; set; }
        public string telNumber { get; set; }
    }
}
