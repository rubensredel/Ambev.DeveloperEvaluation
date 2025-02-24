using Ambev.DeveloperEvaluation.Application.Products.Create;
using Ambev.DeveloperEvaluation.Application.Products.GetAll;
using Ambev.DeveloperEvaluation.Domain.Resources;
using Ambev.DeveloperEvaluation.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products;

[Authorize]
public class ProductsController(IMediator mediator) : BaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateProductResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> CreateSale([FromBody] CreateProductCommand request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);

        return Created(nameof(GetSales), new { id = result.Id }, result);
    }

    [HttpGet(Name = nameof(GetSales))]
    [ProducesResponseType(typeof(PaginatedResponse<GetAllProductsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetSales(CancellationToken cancellationToken)
    {
        var command = new GetAllProductsCommand();

        var response = await mediator.Send(command, cancellationToken);

        return Ok(response);
    }
}
