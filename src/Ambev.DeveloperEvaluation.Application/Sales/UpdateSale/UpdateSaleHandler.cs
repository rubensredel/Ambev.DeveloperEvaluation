using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.Notification;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly ISalesRepository _salesRepository;

    public UpdateSaleHandler(IMapper mapper, IMediator mediator, ISalesRepository salesRepository)
    {
        _mapper = mapper;
        _mediator = mediator;
        _salesRepository = salesRepository;
    }

    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateSaleValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var old = await _salesRepository.GetByIdAsync(request.Id, cancellationToken) ?? throw new KeyNotFoundException($"Sales with ID {request.Id} not found");

        var sale = _mapper.Map<Domain.Entities.Sales>(request);
        sale.Number = old.Number;
        sale.UpdatedAt = DateTime.UtcNow;
        foreach (var item in sale.Items)
        {
            item.UpdatedAt = DateTime.UtcNow;
            item.Total = item.Quantity * item.Price;
        }

        var quantityAbove4PerProduct = sale.Items
            .GroupBy(order => order.ProductId)
            .Select(group => new
            {
                ProductId = group.Key,
                TotalQuantity = group.Sum(order => order.Quantity)
            })
            .Where(group => group.TotalQuantity >= 4);

        foreach (var product in quantityAbove4PerProduct)
        {
            var discount = 0.1M;
            if (product.TotalQuantity >= 10)
                discount = 0.2M;
            var itemsToDiscount = sale.Items.Where(i => i.ProductId == product.ProductId).ToList();
            foreach (var item in itemsToDiscount)
            {
                item.Discount = discount;
                item.Total = item.Total - (item.Total * discount);
            }
        }

        sale.Total = sale.Items.Sum(i => i.Total);

        await _salesRepository.UpdateAsync(sale, cancellationToken);
        var updated = await _salesRepository.GetByIdAsync(request.Id, cancellationToken);

        if (!old.IsCanceled && updated.IsCanceled)
            await _mediator.Publish(new SaleCanceledNotification(updated), cancellationToken);

        foreach (var item in updated.Items)
        {
            var oldItem = old.Items.FirstOrDefault(i => i.Id == item.Id);
            if (!oldItem.IsCanceled && item.IsCanceled)
                await _mediator.Publish(new ItemCanceledNotification(item), cancellationToken);
        }
        await _mediator.Publish(new SaleModifiedNotification(updated), cancellationToken);

        return _mapper.Map<UpdateSaleResult>(updated);
    }
}
