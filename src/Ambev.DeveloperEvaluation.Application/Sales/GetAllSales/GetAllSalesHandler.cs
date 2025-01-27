using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Resources;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

public class GetAllSalesHandler : IRequestHandler<GetAllSalesCommand, PaginatedResult<GetSaleResult>>
{
    private readonly IMapper _mapper;
    private readonly ISalesRepository _salesRepository;

    public GetAllSalesHandler(ISalesRepository salesRepository, IMapper mapper)
    {
        _mapper = mapper;
        _salesRepository = salesRepository;
    }

    public async Task<PaginatedResult<GetSaleResult>> Handle(GetAllSalesCommand request, CancellationToken cancellationToken)
    {
        var sales = await _salesRepository.GetAllAsync(request);
        return _mapper.Map<PaginatedResult<GetSaleResult>>(sales);
    }
}
