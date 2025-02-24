using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAll;

public class GetAllProductsHandler(IProductsRepository repository, IMapper mapper) : IRequestHandler<GetAllProductsCommand, GetAllProductsResponse>
{
    public async Task<GetAllProductsResponse> Handle(GetAllProductsCommand request, CancellationToken cancellationToken)
    {
        var products = await repository.GetAllAsync();
        var response = new GetAllProductsResponse { Products = mapper.Map<IList<GetProductResponse>>(products) };
        return response;
    }
}
