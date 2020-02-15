using Microsoft.AspNetCore.Mvc;
using TelephoneBook.Data;
using TelephoneBook.DataAccessLayers;
using TelephoneBook.Databases;
using TelephoneBook.Helper;
using TelephoneBook.Models;

namespace TelephoneBook.Controllers
{
    public class AdminController : Controller
    {
        // Veritabanıyla olan bağlantıyı sağlamak için gerekli ara katmanın yapısı.
        private DataContext context;
        private IAdminDal adminDal;

        public AdminController(DataContext dataContext)
        {
            context = dataContext;
            adminDal = new SqlServer(context);
        }

        // Admin sistemine giriş işlemi.
        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            if (ModelState.IsValid)
            {
                var adminInfos = adminDal.login(admin);

                if (adminInfos == null)
                {
                    TempData["message"] = "Giriş başarısız !";

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    HttpContext.Session.SetObjectAsJson("adminInfos", adminInfos);

                    return RedirectToAction("Index", "Admin");
                }
            }
            else
            {
                TempData["message"] = "Giriş başarısız !";

                return RedirectToAction("Index", "Home");
            }
        }

        // Çıkış işlemi: halihazırda login olan kullanıcının bilgilerinin temizlenmesi.
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        // Admin şifre güncelleme işlemi.
        [HttpPost]
        public IActionResult UpdatePassword(Admin newAdmin)
        {
            Admin currentAdmin = HttpContext.Session.GetObjectFromJson<Admin>("adminInfos");

            var oldAdmin = adminDal.updatePassword(currentAdmin, newAdmin);

            HttpContext.Session.SetObjectAsJson("adminInfos", oldAdmin);

            TempData["message"] = "Şifreniz başarıyla güncellendi !";

            return RedirectToAction("Index", "Admin");
        }

        // adminUI: adminUI'a girilirken login kontrolü yapılıyor daha sonra bu UI'daki ilgili dropdownlar dolduruluyor.
        public IActionResult Index()
        {
            MultipleModel mm = new MultipleModel();
            mm.admin = HttpContext.Session.GetObjectFromJson<Admin>("adminInfos");

            var result = adminDal.isLoginValid(mm);

            adminDal.fillDropdowns(mm);

            if (result.admin == null)
            {
                MultipleModel emptyMM = new MultipleModel();
                emptyMM.admin.nick = "empty";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(mm);
            }
        }
    }
}