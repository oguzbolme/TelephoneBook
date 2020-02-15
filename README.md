# TelephoneBook ( Telefon Rehberi)
# Anasayfa
Site ilk açıldığında publicUI dediğimiz arayüzü görüyoruz. Buradan şirketteki çalışanların ad,soyad,telefon numarası bilgilerine ulaşabiliyoruz. Eğer detay göstere tıklanırsa tıklanılan çalışanın departman adına ve yöneticisinin bilgisine de ulaşabiliyoruz.
![mainPage](https://user-images.githubusercontent.com/56116374/74592787-d5485e80-5035-11ea-930e-15ad97269d06.png)

# Çalışan Detayları
Herhangi bir çalışanın üstüne veya "Detay Göster" tıklanıldığında o çalışan hakkındaki detay bilgiler gösterilir.
![empDetails](https://user-images.githubusercontent.com/56116374/74592973-aa5f0a00-5037-11ea-9a1b-29af007282da.png)

# Hızlı Arama
"Hızlı Arama" kısmından aramak istediğimiz çalışanın adını,soyadını veya başka bir özelliğini yazarak arama sonuçlarının daha verimli çıkmasını sağlıyoruz.
![searchEmp](https://user-images.githubusercontent.com/56116374/74592873-96ff6f00-5036-11ea-9590-a381c03453ba.png)

# Admin Girişi
Sitenin üstünde yer alan "Admin Girişi" kısmına tıkladıktan sonra bilgilerimizi doldurarak Admin Sistemine girebiliyoruz (yani adminUI'a). Giriş yaptıktan sonra "Admin Girişi" butonu o an hangi admin girdiyse onun kullanıcı adı oluyor ve o buton dropdown'a dönüşüyor. O dropdown'ın altındaki butonlar şu şekilde:
![adminSkills](https://user-images.githubusercontent.com/56116374/74593038-7e905400-5038-11ea-86f9-3d7a52719eaa.png)

# Admin Sistemi: Çalışan İşlemleri
Çalışan işlemleri sekmesinde bulunan 3 adet işlem şu şekilde: Çalışan Ekle, Çalışan Sil, Çalışan Düzenle ve bu işlemlerde uygulanan kural ise eğer silmek istediğiniz çalışan bir başka çalışanın yönetici konumunda bulunuyorsa o çalışan silinemez.
![addEmp](https://user-images.githubusercontent.com/56116374/74593120-14c47a00-5039-11ea-9d48-f228656617e1.png)
![deleteEmp](https://user-images.githubusercontent.com/56116374/74593124-1db54b80-5039-11ea-8614-1929294dba1c.png)
![editEmp](https://user-images.githubusercontent.com/56116374/74593129-273eb380-5039-11ea-95ff-fc0cf06abbe1.png)

# Admin Sistemi: Departman İşlemleri
Departman işlemleri sekmesinde bulunan 3 adet işlem şu şekilde: Departman Ekle, Departman Sil, Departman Düzenle ve bu işlemlerde uygulanan kural ise eğer silmek istediğiniz departmanda çalışan kişiler varsa o departman silinemez.
![addDep](https://user-images.githubusercontent.com/56116374/74593190-bba91600-5039-11ea-9d36-0838debaeefe.png)
![deleteDep](https://user-images.githubusercontent.com/56116374/74593194-be0b7000-5039-11ea-82fd-17b9fbb634af.png)
![editDep](https://user-images.githubusercontent.com/56116374/74593197-c2d02400-5039-11ea-973a-8798efbb6b8a.png)

# Admin Sistemi: Admin Şifre Güncelleme İşlemi
Resimde de görüldüğü gibi "nuevo" adlı dropdown'daki şifreyi güncelle kısmına tıklandığında çıkan modal ile şifremizi güncelleyebiliyoruz.
![updatePassword](https://user-images.githubusercontent.com/56116374/74593220-09be1980-503a-11ea-81a8-4fd71d0ebda1.png)
