using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.Notification;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.Event;

public class ItemCanceledHandler : INotificationHandler<ItemCanceledNotification>
{
    private readonly ILogger<ItemCanceledHandler> _logger;
    public ItemCanceledHandler(ILogger<ItemCanceledHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ItemCanceledNotification notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Item canceled: {SaleItem}", notification.SaleItem);
        return Task.CompletedTask;
    }
}
