using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.Notification;

public record SaleModifiedNotification(Domain.Entities.Sales Sale) : INotification;