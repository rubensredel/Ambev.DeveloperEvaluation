using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Resources;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISalesRepository
{
    Task<PaginatedResponse<Sales>> GetAllAsync(IPageQuery pageQuery);
    Task<Sales> CreateAsync(Sales sales, CancellationToken cancellationToken = default);
    Task<Sales?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Sales?> GetByNumberAsync(int number, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(Sales sales, CancellationToken cancellationToken = default);
}
