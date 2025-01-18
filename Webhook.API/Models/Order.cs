namespace Webhook.API.Models;

public sealed record Order(Guid id, string customerName, decimal amount, DateTime createdDate);

