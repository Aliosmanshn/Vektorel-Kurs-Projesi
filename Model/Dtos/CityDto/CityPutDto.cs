using CommonTypes.Model;

namespace Model.Dtos.CityDto
{
    public class CityPutDto : IDto
    {
        public short Id { get; set; }

        public byte? Countryid { get; set; }

        public string? City1 { get; set; }
    }
}
