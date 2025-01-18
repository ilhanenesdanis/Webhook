using Webhook.API.Abstract;
using Webhook.API.Models;

namespace Webhook.API.Concrete
{
    public class WebhookSubsriptionRepository : IWebhookSubsriptionRepository
    {
        public Task AddWebhook(WebhookSubscrition subscrition)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<WebhookSubscrition> GetSubscriptions(string eventType)
        {
            throw new NotImplementedException();
        }
    }
}
