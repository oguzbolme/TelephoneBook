using System.Collections.Generic;
using TelephoneBook.Models;

namespace TelephoneBook.Helper
{
    // dropdownlardaki tekrarları engellemek için yazdığım iki metod.
    public class Repeat
    {
        public Department department { get; set; }
        public Employee employee { get; set; }

        // departman seçme dropdownu.
        public static List<Department> departmentRepeat(List<Department> departments)
        {
            List<Department> realDepartments = new List<Department>();

            for (int i = 0; i < departments.Count; i++)
            {
                if (realDepartments.Count == 0)
                {
                    realDepartments.Add(departments[i]);
                }
                else
                {
                    int x = 5;
                    for (int j = 0; j < realDepartments.Count; j++)
                    {
                        if (realDepartments[j].name == departments[i].name)
                        {
                            x = 0;
                            break;
                        }
                        else
                        {
                            x = 1;
                        }
                    }
                    if (x == 1)
                    {
                        realDepartments.Add(departments[i]);
                    }
                    else
                    {
                        // hiç bişi yapma.
                    }
                }
            }
            for (int i = 0; i < realDepartments.Count; i++)
            {
                if (realDepartments[i].name == null)
                {
                    realDepartments.Remove(realDepartments[i]);
                }
            }
            return realDepartments;
        }

        // yönetici seçme dropdownu.
        public static List<Employee> employeeRepeat(List<Employee> employees)
        {
            List<Employee> realEmployees = new List<Employee>();

            for (int i = 0; i < employees.Count; i++)
            {
                if (realEmployees.Count == 0)
                {
                    realEmployees.Add(employees[i]);
                }
                else
                {
                    int x = 5;
                    for (int j = 0; j < realEmployees.Count; j++)
                    {
                        if (realEmployees[j].name + " " + realEmployees[j].surname == employees[i].name + " " + employees[i].surname)
                        {
                            x = 0;
                            break;
                        }
                        else
                        {
                            x = 1;
                        }
                    }
                    if (x == 1)
                    {
                        realEmployees.Add(employees[i]);
                    }
                    else
                    {
                        // hiç bişi yapma.
                    }
                }
            }
            for (int i = 0; i < realEmployees.Count; i++)
            {
                if (realEmployees[i].name == null)
                {
                    realEmployees.Remove(realEmployees[i]);
                }
            }
            return realEmployees;
        }
    }
}
