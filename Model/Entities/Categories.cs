using CommonTypes.Model;

namespace Model.Entities
{
    public partial class Categories : IEntity
    {
    public short Kategoriid { get; set; }

    public string? CategoryName { get; set; }

    public string? CategoryImg { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}


}
