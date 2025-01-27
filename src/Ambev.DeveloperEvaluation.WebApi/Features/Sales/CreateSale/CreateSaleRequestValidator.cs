using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    public CreateSaleRequestValidator()
    {
        RuleFor(x => x.Customer).NotEmpty().WithMessage("Customer is required");
        RuleFor(x => x.Branch).NotEmpty().WithMessage("Branch is required");
        RuleFor(x => x.Items).NotEmpty().WithMessage("Items is required");
        RuleForEach(x => x.Items).SetValidator(new CreateSaleItemsRequestValidator());
    }
}
