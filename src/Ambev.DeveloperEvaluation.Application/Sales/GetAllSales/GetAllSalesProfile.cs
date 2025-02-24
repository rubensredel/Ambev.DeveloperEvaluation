using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Resources;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

public class GetAllSalesProfile : Profile
{
    public GetAllSalesProfile()
    {
        CreateMap<PaginatedResponse<Domain.Entities.Sales>, PaginatedResponse<GetSaleResponse>>();
    }
}
