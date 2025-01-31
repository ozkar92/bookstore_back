using BookStore.Dto.Request;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService service;
        public CustomerController(ICustomerService service)
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
        public async Task<IActionResult> Post(CustomerRequestDto genreRequestDto)
        {
            var response = await service.AddAsync(genreRequestDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> Put(int id, CustomerRequestDto genreRequestDto)
        {
            var response = await service.UpdateAsync(id, genreRequestDto);
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
