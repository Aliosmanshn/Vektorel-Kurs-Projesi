using Businness.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.TownDto;

namespace ProjeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TownController : BaseController
    { //ilçe

        private readonly ITownBs _townBs;

        public TownController(ITownBs townBs)
        {
            _townBs = townBs;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _townBs.GetAsync("Country");//bağlantılı olan yere gönderdik countr1 
            return SendResponse(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TownPutDto dto)
        {
            var result = await _townBs.UpdateAsync(dto);
            return SendResponse(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByid([FromRoute] int id)
        {
            var result = await _townBs.GetByIDAsync(id);
            return SendResponse(result);
        }
        [HttpPost]
        public async Task<IActionResult> Creed([FromBody] TownPostDto dto) //eklenen ürün tekrar gelir şu ürün eklendi
        {
            var result = await _townBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetByid), new { id = result.Data.Town1 }, result.Data); //??
        }
    }
}
