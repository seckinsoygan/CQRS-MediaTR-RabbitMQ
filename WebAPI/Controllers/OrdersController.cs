using CQRS.RabbitMQ.Abstract;
using DataAccess;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMessageProducer _messageProducer;

        public OrdersController(IMessageProducer messageProducer)
        {
            _messageProducer = messageProducer;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(ProductCreateVM productCreateVM)
        {
            Product _product = new()
            {
                Id = ApplicationDbContext.ProductList.Count + 1,
                Name = productCreateVM.Name,
                Price = productCreateVM.Price,
                Quantity = productCreateVM.Quantity,
                CreateTime = DateTime.Now,
                UpdateTime = null,
            };
            ApplicationDbContext.ProductList.Add(_product);
            _messageProducer.SendMessage(_product);

            return Ok(new { id = _product.Id });
        }
    }
}
