using Microsoft.AspNetCore.Mvc;
using Webhook.API.Abstract;
using Webhook.API.Models;

namespace Webhook.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class OrderController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;

    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    [HttpPost("CreateOrder")]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
    {
        var result = await _orderRepository.CreateOrder(request);
        if (result)
            return Ok();
        return BadRequest();
    }

}
