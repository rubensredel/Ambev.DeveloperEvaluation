namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleItemResponse
{
    public Guid Id { get; set; }
    public Guid SalesId { get; set; }
    public Guid ProductId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal Discount { get; set; }
    public decimal Total { get; set; }
    public bool IsCanceled { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
