using CommonTypes.Model;

namespace Model.Entities
{
    public partial class Country : IEntity
    {
        public byte Id { get; set; }

        public string? Country1 { get; set; }

        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

        public virtual ICollection<City> Cities { get; set; } = new List<City>();
    }


}
