using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

public class UpdateSaleProfile : Profile
{
    public UpdateSaleProfile()
    {
        CreateMap<UpdateSaleRequest, UpdateSaleCommand>();
        CreateMap<UpdateSaleItemsRequest, UpdateSaleItemCommand>();
        CreateMap<UpdateSaleResult, GetSaleResponse>();
        CreateMap<UpdateSaleItemResult, GetSaleItemsResponse>();
    }
}
