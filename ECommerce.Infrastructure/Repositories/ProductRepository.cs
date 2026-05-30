using Microsoft.EntityFrameworkCore;

using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Persistence;

namespace ECommerce.Infrastructure.Repositories;

public class ProductRepository
    : IProductRepository
{
    private readonly ApplicationDbContext
        _context;

    public ProductRepository(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>>
        GetAllAsync()
    {
        return await _context.Products
            .ToListAsync();
    }

    public async Task AddAsync(
        Product product)
    {
        await _context.Products
            .AddAsync(product);

        await _context.SaveChangesAsync();
    }
}