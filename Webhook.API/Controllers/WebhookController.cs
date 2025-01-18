using Microsoft.AspNetCore.Mvc;
using Webhook.API.Abstract;
using Webhook.API.Models;

namespace Webhook.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class WebhookController : ControllerBase
{
    private readonly IWebhookSubsriptionRepository _subsriptionRepository;
    
    public WebhookController(IWebhookSubsriptionRepository subsriptionRepository)
    {
        _subsriptionRepository = subsriptionRepository;
    }

    [HttpPost("AddWebhook")]
    public async Task<IActionResult> AddWebhook([FromBody] CreateWebhookRequest createWebhook)
    {
        await _subsriptionRepository.AddWebhook(createWebhook);
        return Ok();
    }
}
