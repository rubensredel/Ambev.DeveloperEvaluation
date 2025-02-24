using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Resources;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

public class GetAllSalesHandler(ISalesRepository salesRepository, IMapper mapper) : IRequestHandler<GetAllSalesCommand, PaginatedResponse<GetSaleResponse>>
{
    public async Task<PaginatedResponse<GetSaleResponse>> Handle(GetAllSalesCommand request, CancellationToken cancellationToken)
    {
        var sales = await salesRepository.GetAllAsync(request);
        return mapper.Map<PaginatedResponse<GetSaleResponse>>(sales);
    }
}
