using CommonTypes.Model;

namespace Model.Entities
{
    public partial class City : IEntity
    {
    public short Id { get; set; }

    public byte? Countryid { get; set; }

    public string? City1 { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Country? Country { get; set; }

    public virtual ICollection<Town> Towns { get; set; } = new List<Town>();
}

}

