using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleProfile : Profile
{
    public GetSaleProfile()
    {
        CreateMap<Domain.Entities.Sales, GetSaleResult>();
        CreateMap<Domain.Entities.SalesItem, GetSaleItemResult>();
    }
}
