using CommonTypes.Model;

namespace Model.Entities
{

    public partial class District : IEntity
    {
    public int Id { get; set; }

    public int? Townid { get; set; }

    public string? District1 { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Town? Town { get; set; }
}

}
