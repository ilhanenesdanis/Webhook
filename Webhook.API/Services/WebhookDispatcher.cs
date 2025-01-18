using Webhook.API.Abstract; 

namespace Webhook.API.Services;

public sealed class WebhookDispatcher
{
    private readonly HttpClient _httpClient;
    private readonly IWebhookSubsriptionRepository _webhookSubsription;

    public WebhookDispatcher(HttpClient httpClient, IWebhookSubsriptionRepository webhookSubsription)
    {
        _httpClient = httpClient;
        _webhookSubsription = webhookSubsription;
    }

    public async Task DispatchAsync(string eventType, object payload)
    {
        var subs = await _webhookSubsription.GetSubscriptions(eventType);

        foreach (var sub in subs)
        {
            var request = new
            {
                Id = Guid.NewGuid(),
                sub.EventType,
                SubsriptionId = sub.Id,
                Timestamp = DateTime.UtcNow,
                Data = payload
            };

            await _httpClient.PostAsJsonAsync(sub.WebhookUrl, request);
        }
    }
}
