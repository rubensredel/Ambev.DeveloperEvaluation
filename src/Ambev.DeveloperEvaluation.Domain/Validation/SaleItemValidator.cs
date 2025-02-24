﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleItemValidator : AbstractValidator<SalesItem>
{
    public SaleItemValidator(bool isUpdated = false)
    {
        if (isUpdated)
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Sale item id is required");
        }
        RuleFor(x => x.ProductId)
           .NotEmpty()
           .WithMessage("ProductId is required");
        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than 0");
        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0");
    }
}
