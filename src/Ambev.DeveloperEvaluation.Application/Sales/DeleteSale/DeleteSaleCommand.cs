using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

public class DeleteSaleCommand(Guid id) : IRequest<DeleteSaleResult>
{
    public Guid Id { get; } = id;
}
