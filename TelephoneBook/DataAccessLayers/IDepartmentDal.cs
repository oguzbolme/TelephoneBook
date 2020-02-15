using System;
using TelephoneBook.Models;

namespace TelephoneBook.DataAccessLayers
{
    // departman işlemlerinin arayüzü.
    // eğer projeye sonradan başka bir veritabanı eklenmek istenirse gerekli gördüğüm bir interface.
    // Dal: data access layer: veri erişim katmanı.
    interface IDepartmentDal
    {
        public Boolean addDepartment(Department department);
        public Boolean deleteDepartment(int id);

        public void editDepartment(Department department);
    }
}
