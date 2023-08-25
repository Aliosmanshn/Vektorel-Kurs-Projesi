using Businness.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.CommentDto;

namespace ProjeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : BaseController
    {  // Yorumlar
        private readonly ICommentBs _commentBs;


        public CommentsController(ICommentBs commentBs)
        {
            _commentBs = commentBs;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // emin değilim buradan
            var result = await _commentBs.GetAsync("Trip");//bağlantılı olan yere gönderdik  
            return SendResponse(result);
        }
             
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _commentBs.DeleteAsync(id);
            return SendResponse(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CommentPutDto dto)
        {
            var result = await _commentBs.UpdateAsync(dto);
            return SendResponse(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByid([FromRoute] int id)
        {
            var result = await _commentBs.GetByIDAsync(id);
            return SendResponse(result);
        }
        [HttpPost]
        public async Task<IActionResult> Creed([FromBody] CommentPostDto dto) //eklenen ürün tekrar gelir şu ürün eklendi
        {
            var result = await _commentBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetByid), new { id = result.Data.Yorumid }, result.Data); //emin değilim
        }
    }
}
