using CommonTypes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.CategoryDto
{
    public class CategoryGetDto : IDto
    {
        public short Kategoriid { get; set; }

        public string? CategoryName { get; set; }

        public string? CategoryImg { get; set; }
    }
}
