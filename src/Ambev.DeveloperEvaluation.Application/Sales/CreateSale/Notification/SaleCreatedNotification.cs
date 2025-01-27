using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale.Notification;

public record SaleCreatedNotification(Domain.Entities.Sales Sale) : INotification;