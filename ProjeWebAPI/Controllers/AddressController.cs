using Businness.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.AddressDto;

namespace ProjeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : BaseController
    {
        private readonly IAddressBs _addressBs;


        public AddressController(IAddressBs addressBs)
        {
            _addressBs = addressBs;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _addressBs.GetAsync("Counrty", "City", "Town", "District");//bağlantılı olan yere gönderdik countr1 
            //bakılması gerek
            return SendResponse(result);
        }


    
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _addressBs.DeleteAsync(id);
            return SendResponse(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AddressPutDto dto)
        {
            var result = await _addressBs.UpdateAsync(dto);
            return SendResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByid([FromRoute] int id)
        {
            var result = await _addressBs.GetByIDAsync(id);
            return SendResponse(result);
        }
        [HttpPost]
        public async Task<IActionResult> Creed([FromBody] AddressPostDto dto) //eklenen ürün tekrar gelir şu ürün eklendi
        {
            var result = await _addressBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetByid), new { id = result.Data.Id }, result.Data);
        }
    }
}
