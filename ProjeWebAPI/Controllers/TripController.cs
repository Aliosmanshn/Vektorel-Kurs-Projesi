using Businness.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.TripDto;

namespace ProjeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : BaseController
    { //Geziler 
        private readonly ITripBs _tripBs;

        public TripController(ITripBs tripBs)
        {
            _tripBs = tripBs;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _tripBs.GetAsync("Counrty");//bağlantılı olan yere gönderdik countr1 
            return SendResponse(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TripPutDto dto)
        {
            var result = await _tripBs.UpdateAsync(dto);
            return SendResponse(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByid([FromRoute] int id)
        {
            var result = await _tripBs.GetByIDAsync(id);
            return SendResponse(result);
        }
        [HttpPost]
        public async Task<IActionResult> Creed([FromBody] TripPostDto dto) //eklenen ürün tekrar gelir şu ürün eklendi
        {
            var result = await _tripBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetByid), new { id = result.Data.TripId }, result.Data);
        }
    }
}
