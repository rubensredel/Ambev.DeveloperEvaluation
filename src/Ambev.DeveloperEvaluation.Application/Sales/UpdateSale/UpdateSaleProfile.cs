using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleProfile : Profile
{
    public UpdateSaleProfile()
    {
        CreateMap<UpdateSaleCommand, Domain.Entities.Sales>();
        CreateMap<UpdateSaleItemCommand, Domain.Entities.SalesItem>();
        CreateMap<Domain.Entities.Sales, UpdateSaleResponse>();
        CreateMap<Domain.Entities.SalesItem, UpdateSaleItemResponse>();
    }
}
