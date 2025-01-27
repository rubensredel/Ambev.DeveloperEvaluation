using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    public string Customer { get; set; } = string.Empty;
    public string Branch { get; set; } = string.Empty;
    public IList<CreateSaleItemCommand> Items { get; set; } = [];
    public CreateSaleCommand(string customer, string branch, IList<CreateSaleItemCommand> items)
    {
        Customer = customer;
        Branch = branch;
        Items = items;
    }
}
