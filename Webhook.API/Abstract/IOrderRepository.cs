
using Webhook.API.Models;

namespace Webhook.API.Abstract;

public interface IOrderRepository
{
    Task<bool> CreateOrder(CreateOrderRequest request);

}
