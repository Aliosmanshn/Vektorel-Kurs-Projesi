using CommonTypes.Model;

namespace Model.Entities
{
    public partial class Trip :IEntity
{
    public short TripId { get; set; }

    public string? TripnName { get; set; }

    public string? TripExplanation { get; set; }

    public string? TripImg { get; set; }

    /// <summary>
    /// getdate()
    /// </summary>
    public DateTime? TripDate { get; set; }

    public byte? TripScore { get; set; }

    public short? Kategoriid { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Categories? Kategori { get; set; }
}


}
