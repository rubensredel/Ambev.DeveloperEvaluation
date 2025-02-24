namespace Ambev.DeveloperEvaluation.Domain.Resources;

public class PaginatedResponse<TEntity>(IEnumerable<TEntity> data, int page, int pageSize, int totalItems)
{
    public IEnumerable<TEntity> Data { get; } = data;
    public int Page { get; } = page;
    public int PageSize { get; } = pageSize;
    public int TotalItems { get; } = totalItems;
}
