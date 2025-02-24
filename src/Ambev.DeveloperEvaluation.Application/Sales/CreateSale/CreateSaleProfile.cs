using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {   
        CreateMap<CreateSaleCommand, Domain.Entities.Sales>();
        CreateMap<CreateSaleItemCommand, Domain.Entities.SalesItem>();
        CreateMap<Domain.Entities.Sales, CreateSaleResponse>();
        CreateMap<Domain.Entities.SalesItem, CreateSaleItemResponse>();
    }
}
