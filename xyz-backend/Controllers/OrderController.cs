using Microsoft.AspNetCore.Mvc;
using xyz_backend.Services;
using xyz_backend.Models;
using xyz_backend.Models.ViewModels;

namespace xyz_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {

        private OrderService _orderService;
        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        public IActionResult makeOrder(Order order)
        {
            return Ok(_orderService.makeOrder(order).Result);
        }
        [HttpGet("all")]
        public IActionResult getAll()
        {
            return Ok(_orderService.getAll().Result);
        }
        [HttpGet("single/{id:length(24)}")]
        public IActionResult getAllUserById(string id)
        {
            return Ok(_orderService.getAllUserById(id).Result);
        }
        [HttpPost("change")]
        public IActionResult changeStatus(ChangeStatus changeStatus)
        {
            return Ok(_orderService.changeStatusFn(changeStatus).Result);
        }


    }
}