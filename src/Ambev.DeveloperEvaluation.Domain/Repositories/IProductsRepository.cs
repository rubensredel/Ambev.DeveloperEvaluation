using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IProductsRepository
{
    Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);
    Task<IList<Product>> GetAllAsync();
}
