using CommonTypes.Model;

namespace Model.Dtos.DistrictDto
{
    public class DistrictGetDto : IDto
    {
        public int Id { get; set; }

        public int? TownName { get; set; }

        public string? District1 { get; set; }

        public string? Addresstext { get; set; }
    }
}
