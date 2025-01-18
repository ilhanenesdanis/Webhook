namespace Webhook.API.Models;

public sealed record WebhookSubscrition(Guid Id,string EventType,string WebhookUrl,DateTime createOnUtc);


public sealed record CreateWebhookRequest(string EventType,string WebhookUrl);


