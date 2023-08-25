using CommonTypes.Model;

namespace Model.Dtos.CityDto
{
    public class CityPostDto : IDto
    {
       

        public byte? Countryid { get; set; }

        public string? City1 { get; set; }
    }
}
