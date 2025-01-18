using Webhook.API.Models;

namespace Webhook.API.Abstract
{
    public interface IWebhookSubsriptionRepository
    {
        Task AddWebhook(WebhookSubscrition subscrition);
        IReadOnlyList<WebhookSubscrition> GetSubscriptions(string eventType);
    }
}
