using Microsoft.AspNetCore.Mvc;
using TelephoneBook.Data;
using TelephoneBook.DataAccessLayers;
using TelephoneBook.Databases;
using TelephoneBook.Helper;
using TelephoneBook.Models;

namespace TelephoneBook.Controllers
{
    public class HomeController : Controller
    {
        // Veritabanıyla olan bağlantıyı sağlamak için gerekli ara katmanın yapısı.
        private DataContext context;
        private IEmployeeDal employeeDal;

        public HomeController(DataContext dataContext)
        {
            context = dataContext;
            employeeDal = new SqlServer(context);
        }

        // publicUI: publicUI'a girilirken login kontrolü yapılıyor daha sonra çalışanların publicUI'da gözükmesi için çalışan listesi modele aktarılıyor.
        public IActionResult Index()
        {
            MultipleModel mm = new MultipleModel();
            mm.admin = HttpContext.Session.GetObjectFromJson<Admin>("adminInfos");

            IAdminDal adminDal = new SqlServer(context);
            var result = adminDal.isLoginValid(mm);

            if (result.admin == null)
            {
                MultipleModel emptyMM = new MultipleModel();
                emptyMM.admin.nick = "empty";

                employeeDal.getAllEmployee(emptyMM);

                return View(emptyMM);
            }
            else
            {
                employeeDal.getAllEmployee(mm);

                return View(mm);
            }
        }

        // ana view'da ajax'ın sayfa her yenilendiğinde kullanıcının login yapıp yapmadığını denetlemesi için boş bir get metodu.
        [HttpGet]
        public void Ajax()
        {
            return;
        }
    }
}