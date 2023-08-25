using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace GeziProjesiUI.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public Guid UserId { get; set; }


        [DisplayName("Kullanıcı Adı")]
        [Required]
        [StringLength(30)]
        public string? Username { get; set; }


        [DisplayName("Şifre")]
        [Required]
        [StringLength(100)]
        public string? Password { get; set; }


        [StringLength(50)]
        [DisplayName("İsim Soyisim ")]
        [Required]
        public string? Namesurname { get; set; }

        [Required]
        public string? Email { get; set; }


        [DisplayName("Cinsiyeti")]
        public string? Gender { get; set; }


        [DisplayName("Doğum Tarihi")]
        public DateTime? Birthdate { get; set; }



        [DisplayName("Oluşturulma  Tarihi")]
        public DateTime Createddate { get; set; } = DateTime.Now;


        public string? Telnr1 { get; set; }


        public string? Telnr2 { get; set; }

        public bool Locked { get; set; } = false;


        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "user"; // yeni kullanıcılar user olarak geliyor

        // public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

        // public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }


}
