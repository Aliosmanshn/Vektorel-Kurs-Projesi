using CommonTypes.Model;

namespace Model.Dtos.CategoryDto
{
    public class CategoryPutDto : IDto
    {
        public short Kategoriid { get; set; }

        public string? CategoryName { get; set; }

        public string? CategoryImg { get; set; }
    }
}
