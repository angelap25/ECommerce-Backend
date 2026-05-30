using MediatR;

using ECommerce.Application.Interfaces;

using ECommerce.Domain.Entities;

using ECommerce.Application.Features.Products.Commands;

namespace ECommerce.Application.Features.Products.Handlers;

public class CreateProductCommandHandler
    : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository
        _repository;

    public CreateProductCommandHandler(
        IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = new Product(
            request.Name,
            request.Description,
            request.Price,
            request.Stock,
            request.CategoryId);

        await _repository.AddAsync(product);

        return product.Id;
    }
}