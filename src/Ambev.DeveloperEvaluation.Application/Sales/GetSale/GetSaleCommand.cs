using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleCommand : IRequest<GetSaleResponse>
{
    public Guid Id { get; }

    public GetSaleCommand(Guid id)
    {
        Id = id;
    }
}
