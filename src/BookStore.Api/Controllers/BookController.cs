using BookStore.Dto.Request;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService service;
        public BookController(IBookService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await service.GetAsync();
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await service.GetAsync(id);
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(BookRequestDto bookRequestDto)
        {
            var response = await service.AddAsync(bookRequestDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> Put(int id, BookRequestDto bookRequestDto)
        {
            var response = await service.UpdateAsync(id, bookRequestDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await service.DeleteAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
