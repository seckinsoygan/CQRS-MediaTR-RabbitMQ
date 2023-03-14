using CQRS.Commands.Request;
using CQRS.Commands.Response;
using CQRS.Queries.Request;
using CQRS.Queries.Response;
using CQRS.RabbitMQ;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IMediator _mediator;
        RabbitMQService _rabbitMQService=new RabbitMQService();

        public ProductController(IMediator mediator, RabbitMQService rabbitMQService)
        {
            rabbitMQService = _rabbitMQService;
            _mediator= mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest request)
        {
            List<GetAllProductQueryResponse> allproducts = await _mediator.Send(request);
            _rabbitMQService.SendMessage("Products Getted.");
            return Ok(allproducts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] GetByIdProductQueryRequest request)
        {
            GetByIdProductQueryResponse product = await _mediator.Send(request);
            _rabbitMQService.SendMessage("Products Getted by Id");
            return Ok(product);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommandRequest request)
        {
            CreateProductCommandResponse response = await _mediator.Send(request);
            _rabbitMQService.SendMessage("Products Added.");
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommandRequest request)
        {
            UpdateProductCommandResponse response = await _mediator.Send(request);
            _rabbitMQService.SendMessage("Products Updated.");
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery] DeleteProductCommandRequest request)
        {
            DeleteProductCommandResponse response = await _mediator.Send(request);
            _rabbitMQService.SendMessage("Products Deleted.");
            return Ok(response);
        }
    }
}
