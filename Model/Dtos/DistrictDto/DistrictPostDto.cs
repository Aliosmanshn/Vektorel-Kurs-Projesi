using CommonTypes.Model;

namespace Model.Dtos.DistrictDto
{
    public class DistrictPostDto : IDto
    {

        public int? Townid { get; set; }

        public string? District1 { get; set; }

        public string? Addresstext { get; set; }
    }
}
