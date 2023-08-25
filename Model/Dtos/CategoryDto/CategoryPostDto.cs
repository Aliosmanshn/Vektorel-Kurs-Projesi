using CommonTypes.Model;

namespace Model.Dtos.CategoryDto
{
    public class CategoryPostDto : IDto
    {

        public string? CategoryName { get; set; }

        public string? CategoryImg { get; set; }
    }
}
