using TelephoneBook.Models;

namespace TelephoneBook.DataAccessLayers
{
    // admin işlemlerinin arayüzü.
    // eğer projeye sonradan başka bir veritabanı eklenmek istenirse gerekli gördüğüm bir interface.
    // Dal: data access layer: veri erişim katmanı.
    interface IAdminDal
    {
        public Admin login(Admin admin);
        public MultipleModel isLoginValid(MultipleModel admin);
        public Admin updatePassword(Admin currentAdmin, Admin newAdmin);

        public void fillDropdowns(MultipleModel mm);
    }
}
