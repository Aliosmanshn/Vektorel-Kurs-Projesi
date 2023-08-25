using CommonTypes.Model;

namespace Model.Dtos.DistrictDto
{
    public class DistrictPutDto : IDto
    {
        public int Id { get; set; }

        public int? Townid { get; set; }

        public string? District1 { get; set; }

        public string? Addresstext { get; set; }
    }
}
