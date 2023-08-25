using Businness.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.CountryDto;

namespace ProjeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : BaseController
    { //ülkeler
        private readonly ICountryBs _countryBs;

        public CountryController(ICountryBs countryBs)
        {
            _countryBs = countryBs;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _countryBs.GetAsync("Counrty");//bağlantılı olan yere gönderdik countr1 
            return SendResponse(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CountryPutDto dto)
        {
            var result = await _countryBs.UpdateAsync(dto);
            return SendResponse(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByid([FromRoute] int id)
        {
            var result = await _countryBs.GetByIDAsync(id);
            return SendResponse(result);
        }
        [HttpPost]
        public async Task<IActionResult> Creed([FromBody] CountryPostDto dto) //eklenen ürün tekrar gelir şu ürün eklendi
        {
            var result = await _countryBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetByid), new { id = result.Data.Id }, result.Data); //??
        }
    }
}
