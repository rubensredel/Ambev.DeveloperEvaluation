using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
{
    public UpdateSaleRequestValidator()
    {
        RuleFor(x => x.Customer).NotEmpty().WithMessage("Customer is required");
        RuleFor(x => x.Branch).NotEmpty().WithMessage("Branch is required");
        RuleFor(x => x.Items).NotEmpty().WithMessage("Items is required");
        RuleForEach(x => x.Items).SetValidator(new UpdateSaleItemsRequestValidator());
    }
}
