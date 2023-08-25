using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GeziProjesiUI.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen bir İsim Soyisim giriniz")]
        [DisplayName("İsim Soyisim ")]
        public string? Namesurname { get; set; }

        [Required(ErrorMessage = "Lütfen bir Eposta giriniz")]
        public string? Email { get; set; }


        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen bir kullanıcı adı giriniz")] //zorunlu giriş yapılacak ve hata mesajı fırlatabilir
        [StringLength(30, ErrorMessage = "Kullanıcı adı en fazla 30 karakter olabilir")]
        public string? Username { get; set; }


        [DisplayName("Şifre")]
        //[DataType(DataType.Password)]
        [Required(ErrorMessage = "Lütfen bir Şifre giriniz")] //zorunlu giriş yapılacak ve hata mesajı fırlatabilir
        [MinLength(6, ErrorMessage = "şifre  en az 6 karakter olabilir")]
        [MaxLength(16, ErrorMessage = "şifre  en çok 16 karakter olabilir")]
        public string? Password { get; set; }

        [DisplayName("Tekrar Şifre")]
        //[DataType(DataType.Password)]
        [Required(ErrorMessage = "Lütfen Tekrar bir Şifre giriniz")] //zorunlu giriş yapılacak ve hata mesajı fırlatabilir
        [MinLength(6, ErrorMessage = "Tekrar şifre  en az 6 karakter olabilir")]
        [MaxLength(16, ErrorMessage = "Tekrar şifre  en çok 16 karakter olabilir")]
        [Compare(nameof(Password))]//karşılaştırma yapar // nameof diye kullanmak ileriye dönük hata almamızda yardımcı
        public string? TekrarPassword { get; set; }


    }


}
