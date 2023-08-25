using Businness.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.DistrictDto;

namespace ProjeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : BaseController
    { //semptler
        private readonly IDistrictBs _districtBs;

        public DistrictController(IDistrictBs districtBs)
        {
            _districtBs = districtBs;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _districtBs.GetAsync("Counrty");//bağlantılı olan yere gönderdik countr1 
            return SendResponse(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DistrictPutDto dto)
        {
            var result = await _districtBs.UpdateAsync(dto);
            return SendResponse(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByid([FromRoute] int id)
        {
            var result = await _districtBs.GetByIDAsync(id);
            return SendResponse(result);
        }
        [HttpPost]
        public async Task<IActionResult> Creed([FromBody] DistrictPostDto dto) //eklenen ürün tekrar gelir şu ürün eklendi
        {
            var result = await _districtBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetByid), new { id = result.Data.Id }, result.Data); //??
        }

    }
}
