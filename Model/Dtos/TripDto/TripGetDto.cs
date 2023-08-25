using CommonTypes.Model;

namespace Model.Dtos.TripDto
{
    public class TripGetDto : IDto
    {
        public short TripId { get; set; }

        public string? TripnName { get; set; }

        public string? TripExplanation { get; set; }

        public string? TripImg { get; set; }

        /// <summary>
        /// getdate()
        /// </summary>
        public DateTime? TripDate { get; set; }

        public byte? TripScore { get; set; }

        public short? KategoriName { get; set; }
    }
}
