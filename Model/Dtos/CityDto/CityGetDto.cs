using CommonTypes.Model;

namespace Model.Dtos.CityDto
{
    public class CityGetDto : IDto
    {
        public short Id { get; set; }

        public byte? CountryName { get; set; }

        public string? City1 { get; set; }
    }
}
