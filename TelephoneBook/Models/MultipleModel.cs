using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelephoneBook.Models
{
    public class MultipleModel
    {
        public Employee employee { get; set; }
        public Contact contact { get; set; }
        public Department department { get; set; }
        public Manager manager { get; set; }
        public Admin admin { get; set; }
        public List<Department> Departments { get; set; }
        public List<Manager> Managers { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Contact> Contacts { get; set; }


        public MultipleModel()
        {
            employee = new Employee();
            contact = new Contact();
            department = new Department();
            manager = new Manager();
            admin = new Admin();
            Departments = new List<Department>();
            Managers = new List<Manager>();
            Employees = new List<Employee>();
            Contacts = new List<Contact>();
        }
    }
}
