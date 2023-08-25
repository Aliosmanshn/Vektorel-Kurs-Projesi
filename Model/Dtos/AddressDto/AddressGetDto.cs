using CommonTypes.Model;

namespace Model.Dtos.AddressDto
{
    public class AddressGetDto : IDto
    {
        public int Id { get; set; }

        public string? UserName{ get; set; }

        public string? CountryName { get; set; }

        public string? CityName { get; set; }

        public string? TownName { get; set; }

        public string? DistrictName { get; set; }

        public string? Postalcode { get; set; }

        public string? Addresstext { get; set; }
    }
}
