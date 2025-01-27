using Ambev.DeveloperEvaluation.Application.Sales.CreateSale.Notification;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale.Event;

public class SaleCreatedHandler : INotificationHandler<SaleCreatedNotification>
{
    private readonly ILogger<SaleCreatedHandler> _logger;

    public SaleCreatedHandler(ILogger<SaleCreatedHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(SaleCreatedNotification notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Sale created: {Sale}", notification.Sale);
        return Task.CompletedTask;
    }
}
