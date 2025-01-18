using Webhook.API.Models;

namespace Webhook.API.Abstract
{
    public interface IWebhookSubsriptionRepository
    {
        Task AddWebhook(CreateWebhookRequest subscrition);
        Task<IReadOnlyList<WebhookSubscrition>> GetSubscriptions(string eventType);
    }
}
