using Webhook.API.Abstract;
using Webhook.API.Models;

namespace Webhook.API.Concrete;

public sealed class OrderRepository : IOrderRepository
{
    private readonly Context _context;

    public OrderRepository(Context context)
    {
        _context = context;
    }

    public async Task<bool> CreateOrder(CreateOrderRequest request)
    {
        if (request is null)
            return false;
        if (string.IsNullOrWhiteSpace(request.customerName))
            return false;
        if (request.amount <= 0)
            return false;

        await _context.Orders.AddAsync(new Order(Guid.NewGuid(), request.customerName, request.amount, DateTime.Now));
        var result = await _context.SaveChangesAsync();

        return result == 1;
    }
}
