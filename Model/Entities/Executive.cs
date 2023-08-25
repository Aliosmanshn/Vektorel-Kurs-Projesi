using CommonTypes.Model;

namespace Model.Entities
{
    public partial class Executive : IEntity
    {
    public byte? Yoneticiid { get; set; }

    public string? YoneticiAd { get; set; }

    public string? YoneticiSifre { get; set; }
}

}

