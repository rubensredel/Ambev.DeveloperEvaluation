using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommand : IRequest<CreateSaleResponse>
{
    public string Customer { get; set; } = string.Empty;
    public string Branch { get; set; } = string.Empty;
    public IList<CreateSaleItemCommand> Items { get; set; } = [];
}
