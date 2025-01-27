using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sales : BaseEntity
{
    public int Number { get; set; }
    public string Customer { get; set; } = string.Empty;
    public decimal Total { get; set; }
    public string Branch { get; set; } = string.Empty;
    public bool IsCanceled { get; set; }
    public IList<SalesItem> Items { get; set; } = [];
}
