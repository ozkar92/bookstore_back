using BookStore.Dto.Request;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService service;
        private readonly IBookService bookService;
        public OrderController(IOrderService service,IBookService bookService)
        {
            this.service = service;
            this.bookService = bookService;
        }
        [HttpGet("{dni}")]
        public async Task<IActionResult> Get(string dni="")
        {
            var response = await service.GetAsync(dni);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(OrderRequestDto orderRequestDto)
        {

            var response = await service.AddAsync(orderRequestDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
