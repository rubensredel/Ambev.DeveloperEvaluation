using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.Create;

public class CreateProductCommand : IRequest<CreateProductResponse>
{
    public string Description { get; set; } = string.Empty;
}