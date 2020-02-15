using Microsoft.AspNetCore.Mvc;
using TelephoneBook.Data;
using TelephoneBook.DataAccessLayers;
using TelephoneBook.Databases;
using TelephoneBook.Models;

namespace TelephoneBook.Controllers
{
    public class EmployeeController : Controller
    {
        // Veritabanıyla olan bağlantıyı sağlamak için gerekli ara katmanın yapısı.
        private DataContext context;
        private IEmployeeDal employeeDal;

        public EmployeeController(DataContext dataContext)
        {
            context = dataContext;
            employeeDal = new SqlServer(context);
        }

        // Çalışan ekleme işlemi.
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            employeeDal.addEmployee(employee);

            TempData["message"] = "Çalışan başarıyla eklendi !";

            return RedirectToAction("Index", "Admin");
        }

        // Çalışan silme işlemi: eğer çalışan bir başka çalışanın yönetici konumundaysa silinememesi.
        [HttpPost]
        public IActionResult DeleteEmployee(int id)
        {
            var result = employeeDal.deleteEmployee(id);

            if (result)
            {
                TempData["message"] = "Çalışan başarıyla silindi !";
            }
            else
            {
                TempData["message"] = "Çalışan kişi yönetici konumunda olduğundan silinemedi !";
            }

            return RedirectToAction("Index", "Admin");
        }

        // Çalışan düzenleme işlemi.
        [HttpPost]
        public IActionResult EditEmployee(Employee employee)
        {
            employeeDal.editEmployee(employee);

            TempData["message"] = "Çalışan başarıyla güncellendi";

            return RedirectToAction("Index", "Admin");
        }
    }
}