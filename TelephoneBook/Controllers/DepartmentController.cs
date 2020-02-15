using Microsoft.AspNetCore.Mvc;
using TelephoneBook.Data;
using TelephoneBook.DataAccessLayers;
using TelephoneBook.Databases;
using TelephoneBook.Models;

namespace TelephoneBook.Controllers
{
    public class DepartmentController : Controller
    {
        // Veritabanıyla olan bağlantıyı sağlamak için gerekli ara katmanın yapısı.
        private DataContext context;
        private IDepartmentDal departmentDal;

        public DepartmentController(DataContext dataContext)
        {
            context = dataContext;
            departmentDal = new SqlServer(context);
        }

        // Departman ekleme işlemi: eğer ilgili departmandan zaten varsa eklememesi.
        [HttpPost]
        public IActionResult AddDepartment(Department department)
        {
            var result = departmentDal.addDepartment(department);

            if (result)
            {
                TempData["message"] = "Departman başarıyla eklendi !";
            }
            else
            {
                TempData["message"] = "Departman eklenemedi !";
            }

            return RedirectToAction("Index", "Admin");
        }

        // Departman silme işlemi: eğer ilgili departmanın altında çalışan varsa silmemesi.
        [HttpPost]
        public IActionResult DeleteDepartment(int id)
        {
            var result = departmentDal.deleteDepartment(id);

            if (result)
            {
                TempData["message"] = "Departman başarıyla silindi !";
            }
            else
            {
                TempData["message"] = "Departmanın altında çalışan olduğundan silinemedi !";
            }

            return RedirectToAction("Index", "Admin");
        }

        // departman düzenleme işlemi.
        [HttpPost]
        public IActionResult EditDepartment(Department department)
        {
            departmentDal.editDepartment(department);

            TempData["message"] = "Departman başarıyla güncellendi !";

            return RedirectToAction("Index", "Admin");
        }
    }
}