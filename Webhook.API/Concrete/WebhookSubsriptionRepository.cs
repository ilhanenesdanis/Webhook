using Microsoft.EntityFrameworkCore;
using Webhook.API.Abstract;
using Webhook.API.Models;

namespace Webhook.API.Concrete
{
    public class WebhookSubsriptionRepository : IWebhookSubsriptionRepository
    {
        private readonly Context _context;

        public WebhookSubsriptionRepository(Context context)
        {
            _context = context;
        }

        public async Task AddWebhook(CreateWebhookRequest subscrition)
        {
            await _context.Webhooks.AddAsync(new WebhookSubscrition(Guid.NewGuid(), subscrition.EventType, subscrition.WebhookUrl, DateTime.UtcNow));

            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<WebhookSubscrition>> GetSubscriptions(string eventType)
        {
            return await _context.Webhooks.Where(x => x.EventType == eventType).AsNoTracking().ToListAsync();
        }
    }
}
