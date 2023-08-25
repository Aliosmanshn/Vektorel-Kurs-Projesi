using CommonTypes.Model;

namespace Model.Dtos.TownDto
{
    public class TownPutDto : IDto
    {
        public int TownsId { get; set; }

        public short? Cityid { get; set; }

        public string? Town1 { get; set; }
    }
}
