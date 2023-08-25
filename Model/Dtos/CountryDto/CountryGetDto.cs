using CommonTypes.Model;

namespace Model.Dtos.CountryDto
{
    public class CountryGetDto : IDto
    {
        public byte Id { get; set; }

        public string? Country1 { get; set; }

        
    }
}
