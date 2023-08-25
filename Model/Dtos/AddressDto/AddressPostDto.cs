using CommonTypes.Model;

namespace Model.Dtos.AddressDto
{
    public class AddressPostDto : IDto
    {
       
        public int? Userid { get; set; }

        public byte? Countryid { get; set; }

        public short? Cityid { get; set; }

        public int? Townid { get; set; }

        public int? Districtid { get; set; }

        public string? Postalcode { get; set; }

        public string? Addresstext { get; set; }
    }
}
