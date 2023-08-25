using Businness.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.ExecutiveDto;

namespace ProjeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExecutiveController : BaseController
    { //Yönetici
        private readonly IExecutiveBs _executiveBs;

        public ExecutiveController(IExecutiveBs executiveBs)
        {
            _executiveBs = executiveBs;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _executiveBs.GetAsync("Counrty");//bağlantılı olan yere gönderdik countr1 
            return SendResponse(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ExecutivePutDto dto)
        {
            var result = await _executiveBs.UpdateAsync(dto);
            return SendResponse(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByid([FromRoute] int id)
        {
            var result = await _executiveBs.GetByIDAsync(id);
            return SendResponse(result);
        }
        [HttpPost]
        public async Task<IActionResult> Creed([FromBody] ExecutivePostDto dto) //eklenen ürün tekrar gelir şu ürün eklendi
        {
            var result = await _executiveBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetByid), new { id = result.Data.Yoneticiid }, result.Data);
        }
    }
}
