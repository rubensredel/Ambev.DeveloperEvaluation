using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.Create;

class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required");
    }
}