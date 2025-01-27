using Ambev.DeveloperEvaluation.Application.Sales.CreateSale.Notification;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly ISalesRepository _salesRepository;
    public CreateSaleHandler(IMapper mapper, IMediator mediator, ISalesRepository salesRepository)
    {
        _mapper = mapper;
        _mediator = mediator;
        _salesRepository = salesRepository;
    }

    public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = _mapper.Map<Domain.Entities.Sales>(request);
        foreach(var item in sale.Items)
            item.Total = item.Quantity * item.Price;

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

        var newSale = await _salesRepository.CreateAsync(sale, cancellationToken);
        // publish notification
        await _mediator.Publish(new SaleCreatedNotification(newSale), cancellationToken);

        return _mapper.Map<CreateSaleResult>(newSale);
    }
}
