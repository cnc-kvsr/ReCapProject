using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba Eklendi";
        public static string CarDeleted = "Araba Kaydı Silindi";
        public static string CarUpdated = "Araba Kaydı Güncellendi";
        public static string CarsListed = "Arabalar Listelendi";
        public static string CarNameInvalid = "Araba İsmi Geçersiz";
        public static string CustomerAdded = "Yeni Müşteri Eklendi";
        public static string CustomerDeleted = "Müşteri Kaydı Silindi";
        public static string CustomerUpdated = "Müşteri Kaydı Güncellendi";
        public static string UserAdded = "Yeni Kullanıcı Eklendi";
        public static string UserDeleted = "Kullanıcı Kaydı Silindi";
        public static string UserUpdated = "Kullanıcı Kaydı Güncellendi";
        public static string CarAvailable = "Araç Müsait";
        public static string CarNotAvailable = "Araç Müşteride";
        public static string ImageNotAdded="Araç resmi eklenmedi";
        public static string ImageAdded = "Araç resmi eklendi";
        public static string CountOfCarImageError = "Araç resmi en fazla beş tane olabilir.";
        public static string ImageDeleted= "Araç resmi silindi";
        public static string AuthorizationDenied="Yetkiniz yok";
        public static string UserRegistered = "Kayıt oldu.";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";

        public static string Listed = "Listelendi";

        public static string Deleted = "Silindi";
    }
}
