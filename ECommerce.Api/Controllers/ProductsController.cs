using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ECommerce.Application.Features.Products.Commands;
using ECommerce.Application.Features.Products.Queries;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController
    : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result =
            await _mediator.Send(
                new GetAllProductsQuery());

        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create(
        CreateProductCommand command)
    {
        var result =
            await _mediator.Send(command);

        return Ok(result);
    }
}