using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
{
    public UpdateSaleValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale id is required");
        RuleFor(x => x.Customer)
            .NotEmpty()
            .WithMessage("Customer is required");
        RuleFor(x => x.Branch)
            .NotEmpty()
            .WithMessage("Branch is required");
        RuleFor(x => x.Items)
            .NotEmpty()
            .WithMessage("Sale items are required");
        RuleForEach(x => x.Items)
            .SetValidator(new UpdateSaleItemValidator());
        RuleFor(x => x.Items)
            .Must(ValidateQuantityProduct).WithMessage("Sales contains products above 20 units");
    }

    private bool ValidateQuantityProduct(IList<UpdateSaleItemCommand> items)
    {
        var quantityAbove20AnyProduct = items
            .GroupBy(order => order.ProductId)
            .Select(group => new
            {
                ProductId = group.Key,
                TotalQuantity = group.Sum(order => order.Quantity)
            })
            .Where(group => group.TotalQuantity > 20);
        return !quantityAbove20AnyProduct.Any();
    }
}
