using Ambev.DeveloperEvaluation.Application.Products.GetProduct;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAll;

public class GetAllProductsResponse
{
    public IList<GetProductResponse> Products { get; set; } = new List<GetProductResponse>();
}
