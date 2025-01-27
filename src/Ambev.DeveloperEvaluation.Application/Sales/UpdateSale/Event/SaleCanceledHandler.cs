using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.Notification;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.Event;

public class SaleCanceledHandler : INotificationHandler<SaleCanceledNotification>
{
    private readonly ILogger<SaleCanceledHandler> _logger;

    public SaleCanceledHandler(ILogger<SaleCanceledHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(SaleCanceledNotification notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Sale canceled: {Sale}", notification.Sale);
        return Task.CompletedTask;
    }
}