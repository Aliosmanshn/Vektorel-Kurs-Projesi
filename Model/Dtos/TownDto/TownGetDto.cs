using CommonTypes.Model;

namespace Model.Dtos.TownDto
{
    public class TownGetDto : IDto
    {
        public int TownsId { get; set; }

        public short? CityName { get; set; }

        public string? Town1 { get; set; }
    }
}
