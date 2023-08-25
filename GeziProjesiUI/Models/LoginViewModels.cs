using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace GeziProjesiUI.Models
{
    public class LoginViewModels
    {
        public int UserId { get; set; }

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

    }

}
