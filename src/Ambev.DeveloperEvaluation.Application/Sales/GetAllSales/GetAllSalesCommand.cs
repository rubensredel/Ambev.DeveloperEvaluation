using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Resources;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

public class GetAllSalesCommand : IRequest<PaginatedResult<GetSaleResult>>, IPageQuery
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}
