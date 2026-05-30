using MediatR;

using ECommerce.Application.Interfaces;

using ECommerce.Application.Features.Products.DTOs;
using ECommerce.Application.Features.Products.Queries;

namespace ECommerce.Application.Features.Products.Handlers;

public class GetAllProductsQueryHandler
    : IRequestHandler<
        GetAllProductsQuery,
        IEnumerable<ProductDto>>
{
    private readonly IProductRepository
        _repository;

    public GetAllProductsQueryHandler(
        IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProductDto>>
        Handle(
            GetAllProductsQuery request,
            CancellationToken cancellationToken)
    {
        var products =
            await _repository.GetAllAsync();

        return products.Select(x =>
            new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Stock = x.Stock
            });
    }
}