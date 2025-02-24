using Ambev.DeveloperEvaluation.Domain.Business;

namespace Ambev.DeveloperEvaluation.Application.Sales;

public class CalculatorSales : ICalculatorSales
{
    public void CalculateTotals(Domain.Entities.Sales sale)
    {
        foreach (var item in sale.Items)
            item.Total = item.Quantity * item.Price;

        var quantityAbove4PerProduct = sale.Items
            .GroupBy(order => order.ProductId)
            .Select(group => new
            {
                ProductId = group.Key,
                TotalQuantity = group.Sum(order => order.Quantity)
            })
            .Where(group => group.TotalQuantity >= 4);

        foreach (var product in quantityAbove4PerProduct)
        {
            var discount = 0.1M;
            if (product.TotalQuantity >= 10)
                discount = 0.2M;
            var itemsToDiscount = sale.Items.Where(i => i.ProductId == product.ProductId).ToList();
            foreach (var item in itemsToDiscount)
            {
                item.Discount = discount;
                item.Total = item.Total - (item.Total * discount);
            }
        }

        sale.Total = sale.Items.Sum(i => i.Total);
    }
}
