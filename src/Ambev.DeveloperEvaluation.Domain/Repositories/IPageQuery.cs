namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IPageQuery
{
    int Page { get; }
    int PageSize { get; }
}
