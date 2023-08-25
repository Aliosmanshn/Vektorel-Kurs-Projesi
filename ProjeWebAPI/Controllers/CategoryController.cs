using Businness.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.CategoryDto;

namespace ProjeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly ICategoryBs _categoryBs;

        public CategoryController(ICategoryBs categoryBs)
        {
            _categoryBs = categoryBs;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _categoryBs.GetAsync("Counrty");//bağlantılı olan yere gönderdik countr1 
            return SendResponse(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CategoryPutDto dto)
        {
            var result = await _categoryBs.UpdateAsync(dto);
            return SendResponse(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByid([FromRoute] int id)
        {
            var result = await _categoryBs.GetByIDAsync(id);
            return SendResponse(result);
        }
        [HttpPost]
        public async Task<IActionResult> Creed([FromBody] CategoryPostDto dto) //eklenen ürün tekrar gelir şu ürün eklendi
        {
            var result = await _categoryBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetByid), new { id = result.Data.Kategoriid }, result.Data);
        }
    }
}
