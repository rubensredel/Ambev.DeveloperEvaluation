using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.Notification;

public record SaleCanceledNotification(Domain.Entities.Sales Sale) : INotification;