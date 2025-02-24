using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Resources;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Extensions;

public static class QueryableExtensions
{
    public static async Task<PaginatedResponse<T>> PaginateAsync<T>(this IQueryable<T> query, IPageQuery pageQuery)
    {
        var count = await query.CountAsync();
        var result = await query.Skip((pageQuery.Page - 1) * pageQuery.PageSize).Take(pageQuery.PageSize).ToListAsync();
        return new PaginatedResponse<T>(result, pageQuery.Page, pageQuery.PageSize, count);
    }
}
