using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.Notification;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.Event;

public class SaleModifiedHandler : INotificationHandler<SaleModifiedNotification>
{
    private readonly ILogger<SaleModifiedHandler> _logger;

    public SaleModifiedHandler(ILogger<SaleModifiedHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(SaleModifiedNotification notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Sale modified: {Sale}", notification.Sale);
        return Task.CompletedTask;
    }
}