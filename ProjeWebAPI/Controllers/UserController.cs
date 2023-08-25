using Businness.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.UserDto;

namespace ProjeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController //bu sayede hem hata mesajı döndürüyoruz hem de controllerbaseye erişim sağlıyıruz
    { //kullanıcı

        private readonly IUserBs _userBs;
        

        public UserController(IUserBs userBs)
        {
            _userBs = userBs;

        }
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var result = await _userBs.GetAsync();
            return SendResponse(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _userBs.DeleteAsync(id);
            return SendResponse(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserPutDto dto)
        {
            var result = await _userBs.UpdateAsync(dto);
            return SendResponse(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByid ([FromRoute] int id)
        {
            var result = await _userBs.GetByIDAsync(id);
            return SendResponse(result);
        }
        [HttpPost]
        public async Task<IActionResult> Creed ([FromBody] UserPostDto dto) //eklenen ürün tekrar gelir şu ürün eklendi
        {
            var result = await _userBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetByid),new {id= result.Data.UserId }, result.Data);
        }
    }
}
