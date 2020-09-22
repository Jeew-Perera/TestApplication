using System.Threading.Tasks;
using BusinessLayer;
using EntityLayer.OrderDto;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _iOrderManager;
        public OrderController(IOrderManager iOrderManager)
        {
            _iOrderManager = iOrderManager;
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder(OrderDto orderDto)
        {
            await _iOrderManager.SaveOrder(orderDto);
            return Ok();

        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> Get(int customerId)
        {
            var orders = await _iOrderManager.GetAllOrderDetails(customerId);
            return Ok(orders);
        }
    }
}
