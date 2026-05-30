using MediatR;

using ECommerce.Application.Features.Products.DTOs;

namespace ECommerce.Application.Features.Products.Queries;

public record GetAllProductsQuery
    : IRequest<IEnumerable<ProductDto>>;