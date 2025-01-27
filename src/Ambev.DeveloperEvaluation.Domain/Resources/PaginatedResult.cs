namespace Ambev.DeveloperEvaluation.Domain.Resources;

public record PaginatedResult<TEntity>
{
    public PaginatedResult(IEnumerable<TEntity> data, int page, int pageSize, int totalItems)
    {
        Data = data;
        Page = page;
        PageSize = pageSize;
        TotalItems = totalItems;
    }
    public IEnumerable<TEntity> Data { get; }
    public int Page { get; }
    public int PageSize { get; }
    public int TotalItems { get; }
}
