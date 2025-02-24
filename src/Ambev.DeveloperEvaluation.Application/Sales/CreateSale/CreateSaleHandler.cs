using Ambev.DeveloperEvaluation.Application.Sales.CreateSale.Notification;
using Ambev.DeveloperEvaluation.Domain.Business;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Validation;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleHandler(IMapper mapper, IMediator mediator, ISalesRepository salesRepository, ICalculatorSales calculator) : IRequestHandler<CreateSaleCommand, CreateSaleResponse>
{
    public async Task<CreateSaleResponse> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = mapper.Map<Domain.Entities.Sales>(request);

        var validator = new SaleValidator();
        var validationResult = await validator.ValidateAsync(sale, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        calculator.CalculateTotals(sale);
 
        var newSale = await salesRepository.CreateAsync(sale, cancellationToken);
        // publish notification
        await mediator.Publish(new SaleCreatedNotification(newSale), cancellationToken);

        return mapper.Map<CreateSaleResponse>(newSale);
    }
}
