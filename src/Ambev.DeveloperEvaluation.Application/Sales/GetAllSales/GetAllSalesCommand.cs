using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Resources;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

public record GetAllSalesCommand(int Page, int PageSize) : IRequest<PaginatedResponse<GetSaleResponse>>, IPageQuery
{
    public int Page { get; } = Page;
    public int PageSize { get; } = PageSize;
}
