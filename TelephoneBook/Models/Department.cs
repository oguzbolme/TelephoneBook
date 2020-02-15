using System.ComponentModel.DataAnnotations;

namespace TelephoneBook.Models
{
    public class Department
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
