using Businness.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.CityDto;

namespace ProjeWebAPI.Controllers

{ //il
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : BaseController
    {
        private readonly ICityBs _cityBs;

        public CityController(ICityBs cityBs)
        {
            _cityBs = cityBs;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _cityBs.GetAsync("Town");//bağlantılı olan yere gönderdik countr1 
            return SendResponse(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CityPutDto dto)
        {
            var result = await _cityBs.UpdateAsync(dto);
            return SendResponse(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByid([FromRoute] int id)
        {
            var result = await _cityBs.GetByIDAsync(id);
            return SendResponse(result);
        }
        [HttpPost]
        public async Task<IActionResult> Creed([FromBody] CityPostDto dto) //eklenen ürün tekrar gelir şu ürün eklendi
        {
            var result = await _cityBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetByid), new { id = result.Data.Id }, result.Data); //??
        }
    }
}
