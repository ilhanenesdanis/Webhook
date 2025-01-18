using Microsoft.AspNetCore.Mvc;
using Webhook.API.Abstract;
using Webhook.API.Models;
using Webhook.API.Services;

namespace Webhook.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class OrderController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;
    private readonly WebhookDispatcher _webhookDispatcher;
    public OrderController(IOrderRepository orderRepository, WebhookDispatcher webhookDispatcher)
    {
        _orderRepository = orderRepository;
        _webhookDispatcher = webhookDispatcher;
    }

    [HttpPost("CreateOrder")]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
    {
        var result = await _orderRepository.CreateOrder(request);


        if (result)
        {
            await _webhookDispatcher.DispatchAsync("Order.Created", request);
            return Ok();
        }
        return BadRequest();
    }

}
