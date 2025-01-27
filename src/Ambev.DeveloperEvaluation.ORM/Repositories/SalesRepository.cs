using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Resources;
using Ambev.DeveloperEvaluation.ORM.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SalesRepository : ISalesRepository
{
    private readonly DefaultContext _context;

    public SalesRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<PaginatedResult<Sales>> GetAllAsync(IPageQuery pageQuery)
    {
        return await _context.Sales.AsNoTracking().Include(x => x.Items).AsQueryable().PaginateAsync(pageQuery);
    }

    public async Task<Sales> CreateAsync(Sales sales, CancellationToken cancellationToken = default)
    {
        await _context.Sales.AddAsync(sales, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return sales;
    }

    public async Task<Sales?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Sales.AsNoTracking().Include(x => x.Items).FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    public async Task<Sales?> GetByNumberAsync(int number, CancellationToken cancellationToken = default)
    {
        return await _context.Sales.AsNoTracking().Include(x => x.Items).FirstOrDefaultAsync(o => o.Number == number, cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var sale = await GetByIdAsync(id, cancellationToken);
        if (sale == null)
            return false;

        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> UpdateAsync(Sales sales, CancellationToken cancellationToken = default)
    {
        _context.Sales.Update(sales);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
