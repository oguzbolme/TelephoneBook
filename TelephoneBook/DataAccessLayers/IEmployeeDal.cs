using System;
using TelephoneBook.Models;

namespace TelephoneBook.DataAccessLayers
{
    // çalışan işlemlerinin arayüzü.
    // eğer projeye sonradan başka bir veritabanı eklenmek istenirse gerekli gördüğüm bir interface.
    // Dal: data access layer: veri erişim katmanı.
    interface IEmployeeDal
    {
        public void addEmployee(Employee employee);
        public Boolean deleteEmployee(int id);
        public void editEmployee(Employee employee);
        public void getAllEmployee(MultipleModel mm);
    }
}
