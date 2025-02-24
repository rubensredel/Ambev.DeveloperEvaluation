using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.Create;

class CreateProductProfile : Profile
{
    public CreateProductProfile()
    {
        CreateMap<CreateProductCommand, Domain.Entities.Product>();
        CreateMap<Domain.Entities.Product, CreateProductResponse>();
    }
}
