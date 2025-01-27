using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class SalesItem : BaseEntity
{
    public Guid SalesId { get; set; }
    public Guid ProductId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal Discount { get; set; }
    public decimal Total { get; set; }
    public bool IsCanceled { get; set; }
    public Sales Sales { get; set; } = null!;
    public Product Product { get; set; } = null!;
}
