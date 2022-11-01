using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserListed = "Kullanıcılar listelendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string TrainerUpdated = "Eğitmen güncellendi";
        public static string TrainerListed = "Eğitmenler listelendi";
        public static string TrainerDeleted = "Eğitmen silindi";
        public static string TrainerAdded = "Eğitmen eklendi";
        public static string TrainerImageUpdated="Eğitmenin fotoğrafı güncellendi";
        public static string TrainerImageListed="Eğitmenlerin fotoğrafları listelendi";
        public static string TrainerImageDeleted="Eğitmenin Fotoğrafı silindi";
        public static string TrainerImageAdded="Eğitmenin fotoğrafı eklendi";
        public static string SportEduAdded="Spor alanında eğitim eklendi";
        public static string SportEduDeleted="Spor alanında ki eğitim silind";
        public static string SportEduListed="Spor alanında ki eğimler listelendi";
        public static string SportEduUpdated="Spor alanında ki eğitim güncellendi.";
        public static string PerDevEduUpdated="kişisel gelişim eğitimi güncellendi";
        public static string PerDevEduListed="Kişisel gelişim eğitimleri listelendi.";
        public static string PerDevEduDeleted="Kişisel gelişim eğitimi silindi";
        public static string PerDevEduAdded="Kişisel gelişim alanına da eğitim eklendi.";
        public static string HSchoolEduUpdated = "Lise eğitimi güncellendi.";
        public static string HSchoolEduListed="Lise kategorisindeki eğitimler listelendi";
        public static string HSchoolEduDeleted="Lise kategorisindeki eğitim silindi";
        public static string HSchoolEduAdded="Lise kategorisi alanında eğitim eklendi";
        public static string FormOfEduAdded="Eğitim biçimi eklendi";
        public static string FormOfEduDeleted="Eğitim biçimi silindi";
        public static string FormOfEduListed="Eğitim biçimleri listelendi";
        public static string FormOfEduUpdated="Eğitim biçimi güncellendi";
        public static string EducationAdded="Eğitim eklendi";
        public static string EducationDeleted="Eğitim silindi";
        public static string EducationListed="Eğitimler listelendi";
        public static string EducationUpdated="Eğitim güncelledi.";
        public static string CategoryAdded="Kategori eklendi";
        public static string CategoryDeleted="Kategori silindi";
        public static string CategoryListed="Kategoriler listelendi";
        public static string CategoryUpdated="Kategori güncellendi";
        public static string AddressAdded="Adres eklendi";
        public static string AddressDeleted="Adres silindi";
        public static string AddressListed="Adresler listelendi";
        public static string AddressUpdated="Adres güncellendi";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError="Parola hatası";
        public static string SuccessfulLogin="Başarılı girş";
        public static string UserAlreadyExists="Kullanıcı mevcut";
        public static string AccessTokenCreated="Token oluşturuldu";
        public static string succeed = "Başarılı";
        public static string TrainerRegistered;

        public static string  TrainerNotFound = "Kullanıcı bulunamadı";
        public static string TrainerAlreadyExists = "Kullanıcı mevcut";
        internal static string UserImageAdded;
        internal static string UserImageDeleted;
        internal static string UserImageListed;
        internal static string UserImageUpdated;
        internal static string passwordChanged;
    }
}
