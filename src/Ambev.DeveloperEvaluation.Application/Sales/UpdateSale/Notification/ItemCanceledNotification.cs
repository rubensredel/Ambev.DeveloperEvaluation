using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.Notification;

public record ItemCanceledNotification(Domain.Entities.SalesItem SaleItem) : INotification;
