using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.Notification;
using Ambev.DeveloperEvaluation.Domain.Business;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Validation;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleHandler(IMapper mapper, IMediator mediator, ISalesRepository salesRepository, ICalculatorSales calculator) : IRequestHandler<UpdateSaleCommand, UpdateSaleResponse>
{
    public async Task<UpdateSaleResponse> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = mapper.Map<Domain.Entities.Sales>(request);

        var validator = new SaleValidator(true);
        var validationResult = await validator.ValidateAsync(sale, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var old = await salesRepository.GetByIdAsync(request.Id, cancellationToken) ?? throw new KeyNotFoundException($"Sales with ID {request.Id} not found");

        sale.Number = old.Number;
        sale.UpdatedAt = DateTime.UtcNow;
        foreach (var item in sale.Items)
        {
            item.UpdatedAt = DateTime.UtcNow;
        }

        calculator.CalculateTotals(sale);

        await salesRepository.UpdateAsync(sale, cancellationToken);
        var updated = await salesRepository.GetByIdAsync(request.Id, cancellationToken);

        if (!old.IsCanceled && updated.IsCanceled)
        {
            await mediator.Publish(new SaleCanceledNotification(updated), cancellationToken);
        }

        foreach (var item in updated.Items)
        {
            var oldItem = old.Items.FirstOrDefault(i => i.Id == item.Id);
            if (!oldItem.IsCanceled && item.IsCanceled)
                await mediator.Publish(new ItemCanceledNotification(item), cancellationToken);
        }
        await mediator.Publish(new SaleModifiedNotification(updated), cancellationToken);

        return mapper.Map<UpdateSaleResponse>(updated);
    }
}
