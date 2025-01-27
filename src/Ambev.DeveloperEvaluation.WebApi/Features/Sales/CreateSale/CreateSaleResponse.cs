namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleResponse
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Customer { get; set; } = String.Empty;
    public decimal Total { get; set; }
    public string Branch { get; set; } = String.Empty;
    public bool IsCanceled { get; set; }
    public IList<CreateSaleItemsResponse> Items { get; set; } = [];
}
