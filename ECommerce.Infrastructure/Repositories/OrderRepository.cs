using Microsoft.EntityFrameworkCore;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Persistence;
using ECommerce.Application.Interfaces; 

namespace ECommerce.Infrastructure.Repositories;
public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _ctx;
    public OrderRepository(ApplicationDbContext ctx) => _ctx = ctx;

    // Eager loading: traer la orden con sus items
    public async Task<Order?> GetByIdWithItemsAsync(Guid id, CancellationToken ct = default)
        => await _ctx.Orders
               .Include(o => o.Items)  // JOIN con OrderItems
               .FirstOrDefaultAsync(o => o.Id == id, ct);

    public async Task<IEnumerable<Order>> GetByUserIdAsync(Guid userId, CancellationToken ct = default)
        => await _ctx.Orders
               .AsNoTracking()
               .Where(o => o.UserId == userId)
               .OrderByDescending(o => o.CreatedAt)
               .ToListAsync(ct);

    public async Task AddAsync(Order order, CancellationToken ct = default)
    {
        await _ctx.Orders.AddAsync(order, ct);
        await _ctx.SaveChangesAsync(ct);
    }
}
