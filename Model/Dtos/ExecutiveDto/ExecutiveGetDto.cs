using CommonTypes.Model;

namespace Model.Dtos.ExecutiveDto
{
    public class ExecutiveGetDto : IDto
    {
        public byte? Yoneticiid { get; set; }

        public string? YoneticiAd { get; set; }

        public string? YoneticiSifre { get; set; }
    }
}
