using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelephoneBook.Data;
using TelephoneBook.DataAccessLayers;
using TelephoneBook.Helper;
using TelephoneBook.Models;

namespace TelephoneBook.Databases
{
    // sql server veritabanında yapılan tüm işlemler.
    // eğer yeni bir veritabanı daha eklenmek isterse bu dosya dizinine ilgili veritabanı örneğin(Oracle Database) eklenmesi ve DataAccessLayersdaki interfacelerden kalıtım alması yeterli.
    public class SqlServer:IAdminDal,IEmployeeDal,IDepartmentDal
    {
        private DataContext context;

        public SqlServer(DataContext dataContext)
        {
            context = dataContext;
        }

        public Boolean addDepartment(Department department)
        {
            // aynı departmandan başka var mı kontrol ediliyor.
            var isThere = context.Departments.FirstOrDefault(x => x.name == department.name);

            if (isThere == null)
            {
                // ekle.
                context.Departments.Add(department);
                context.SaveChanges();

                return true;
            }
            else
            {
                // ekleme.
                return false;
            }
        }

        public void addEmployee(Employee employee)
        {
            // çalışan ekleme işlemi.
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public Boolean deleteDepartment(int id)
        {
            var department = context.Departments.FirstOrDefault(x => x.id == id);
            var employee = context.Employees.FirstOrDefault(x => x.department.name==department.name);

            if (employee == null)
            {
                // bu departmanda çalışan olmadığından silinebilir.
                var departments = context.Departments.Where(x => x.name == department.name).ToList();
                context.Departments.RemoveRange(departments);
                context.SaveChanges();
                return true;
            }
            else
            {
                // bu departmanda çalışan olduğunda silinemez.
                return false;
            }
        }

        public Boolean deleteEmployee(int id)
        {
            // silinecek çalışan ve diğer tablolardaki bilgileri.
            var employee=context.Employees.FirstOrDefault(x => x.id == id);
            var department = context.Departments.FirstOrDefault(x => x.id == employee.departmentID);
            var contact = context.Contacts.FirstOrDefault(x => x.id == employee.contactID);
            var manager = context.Managers.FirstOrDefault(x => x.id == employee.managerID);

            // eşleşmelere bakılıyor.
            var isMatch = context.Managers.FirstOrDefault(x => x.employeeID == employee.id);

            if (isMatch == null)
            {
                // bu kişinin altında kimse çalışmadığından silinebilir.
                context.Managers.Remove(manager);
                context.Contacts.Remove(contact);
                context.Departments.Remove(department);
                context.Employees.Remove(employee);

                context.SaveChanges();

                return true;
            }
            else
            {
                // bu kişinin altında çalışan olduğundan silinemez.
                return false;
            }
        }

        public void editDepartment(Department department)
        {
            var oldDep = context.Departments.FirstOrDefault(x => x.id == department.id);

            // Aynı isme sahip başka departman varsa toplu silme işlemi.
            var departments = context.Departments.Where(x => x.name == oldDep.name).ToList();
            for(int i = 0; i < departments.Count; i++)
            {
                departments[i].name = department.name;
            }

            context.SaveChanges();
        }

        public void editEmployee(Employee employee)
        {
            // çalışan düzenleme işlemi.
            var realEmployee = context.Employees.FirstOrDefault(x => x.id == employee.id);
            var contact = context.Contacts.FirstOrDefault(x => x.id == realEmployee.contactID);
            var department = context.Departments.FirstOrDefault(x => x.id == realEmployee.departmentID);
            var manager = context.Managers.FirstOrDefault(x => x.id == realEmployee.managerID);
            realEmployee.name = employee.name;
            realEmployee.surname = employee.surname;
            realEmployee.contact.telNumber = employee.contact.telNumber;
            realEmployee.department.name = employee.department.name;
            realEmployee.manager.employeeID = employee.manager.employeeID;

            context.SaveChanges();
        }

        public void fillDropdowns(MultipleModel mm)
        {
            // adminUI'daki dropdownların temizlenip listeye aktarılması ve daha sonra modele aktarılması.
            mm.Departments = Repeat.departmentRepeat(context.Departments.ToList());
            mm.Managers = context.Managers.ToList();
            mm.Employees = Repeat.employeeRepeat(context.Employees.ToList());
            mm.Contacts = context.Contacts.ToList();
        }

        public void getAllEmployee(MultipleModel mm)
        {
            // publicUI'daki çalışanların listeye aktarılması ve daha sonra modele aktarılması.
            mm.Employees = context.Employees.ToList();
            mm.Contacts = context.Contacts.ToList();
            mm.Departments = context.Departments.ToList();
            mm.Managers = context.Managers.ToList();
        }

        // kullanıcının hala online olup olmadığını kontrol eden metod.
        public MultipleModel isLoginValid(MultipleModel mm)
        {
            if (mm.admin != null)
            {
                MultipleModel admin1 = new MultipleModel();
                admin1.admin.id = Convert.ToInt32(mm.admin.id);
                admin1.admin.nick = mm.admin.nick;
                admin1.admin.password = mm.admin.password;

                return admin1;
            }
            else
            {
                return mm;
            }
        }

        // login işlemi.
        public Admin login(Admin admin)
        {
            var adminInfos = context.Admins.FirstOrDefault(x => x.nick == admin.nick && x.password == admin.password);
            if (adminInfos == null)
            {
                return null;
            }
            else
            {
                return adminInfos;
            }
        }

        // adminin şifre güncelleme işlemi.
        public Admin updatePassword(Admin currentAdmin, Admin newAdmin)
        {
            Admin oldAdmin = context.Admins.FirstOrDefault(x => x.id == currentAdmin.id);

            oldAdmin.password = newAdmin.password;

            context.SaveChanges();

            return oldAdmin;
        }
    }
}
