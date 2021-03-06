﻿using System.ComponentModel.DataAnnotations;

namespace TelephoneBook.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        [Key]
        public int contactID { get; set; }
        [Key]
        public int departmentID { get; set; }
        [Key]
        public int managerID { get; set; }

        public Contact contact { get; set; }
        public Department department { get; set; }
        public Manager manager { get; set; }
    }
}
