using CommonTypes.Model;
using System.ComponentModel;

namespace Model.Entities
{
    public partial class User : IEntity
    {
    public int UserId { get; set; }


    [DisplayName("Kullanıcı Adı")]
    public string? Username { get; set; }


    [DisplayName("Şifre")]
    public string? Password { get; set; }


    [DisplayName("İsim Soyisim ")]
    public string? Namesurname { get; set; }

    public string? Email { get; set; }


    [DisplayName("Cinsiyeti")]
    public string? Gender { get; set; }


    [DisplayName("Doğum Tarihi")]
    public DateTime? Birthdate { get; set; }



    [DisplayName("Oluşturulma  Tarihi")]
    public DateTime Createddate { get; set; } = DateTime.Now;


    public string? Telnr1 { get; set; }


    public string? Telnr2 { get; set; }
     public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

     
}


}

