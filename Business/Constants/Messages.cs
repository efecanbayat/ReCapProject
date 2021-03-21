using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarNameInvalid = "Araba ismi minimum 2 karakter olmalı veya günlük fiyatı 0'dan büyük olmalıdır";
        public static string CarsListed = "Arabalar listelendi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorNameInvalid = "Renk ismi geçersiz";
        public static string ColorsListed = "Renkler listelendi";       

        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandNameInvalid = "Marka ismi geçersiz";
        public static string BrandsListed = "Markalar listelendi";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserNameInvalid = "Kullanıcı ismi minimum 2 karakter olmalı";
        public static string UsersListed = "Kullanıcılar listelendi";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerNameInvalid = "Müşteri ismi minimum 2 karakter olmalı";
        public static string CustomersListed = "Müşteriler listelendi";

        public static string RentalAdded = "Kiralama işlemi eklendi";
        public static string RentalDeleted = "Kiralama işlemi silindi";
        public static string RentalUpdated = "Kiralama işlemi güncellendi";
        public static string RentalInvalid = "Kiralama işlemi için arabanın teslim edilmiş olması gerekmektedir";
        public static string RentalsListed = "Kiralama işlemleri listelendi";

        public static string ImageAdded = "Resim eklendi";
        public static string ImageDeleted = "Resim silindi";
        public static string ImageUpdated = "Resim güncellendi";
        public static string ImagesListed = "Resimler listelendi";

        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarImageLimitExceeded = "Bir arabanın 5'ten fazla resmi olamaz";
    }
}
