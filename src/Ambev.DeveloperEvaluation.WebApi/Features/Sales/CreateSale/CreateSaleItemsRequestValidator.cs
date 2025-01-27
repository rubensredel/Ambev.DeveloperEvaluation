using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleItemsRequestValidator : AbstractValidator<CreateSaleItemsRequest>
{
    public CreateSaleItemsRequestValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product is required");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0");
    }
}
