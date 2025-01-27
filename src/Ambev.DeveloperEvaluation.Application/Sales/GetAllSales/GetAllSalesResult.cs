using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Resources;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

public record GetAllSalesResult : PaginatedResult<GetSaleResult>
{
    protected GetAllSalesResult(PaginatedResult<GetSaleResult> original) : base(original)
    {}
}
