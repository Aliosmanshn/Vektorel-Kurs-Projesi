using CommonTypes.Model;

namespace Model.Dtos.ExecutiveDto
{
    public class ExecutivePostDto : IDto
    {
        public string? YoneticiAd { get; set; }

        public string? YoneticiSifre { get; set; }
    }
}
