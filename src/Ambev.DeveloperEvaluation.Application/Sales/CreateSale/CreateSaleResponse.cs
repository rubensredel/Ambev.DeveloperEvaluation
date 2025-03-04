﻿namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleResponse
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public string Customer { get; set; } = string.Empty;
    public decimal Total { get; set; }
    public string Branch { get; set; } = string.Empty;
    public bool IsCanceled { get; set; }
    public IList<CreateSaleItemResponse> Items { get; set; } = [];
}
