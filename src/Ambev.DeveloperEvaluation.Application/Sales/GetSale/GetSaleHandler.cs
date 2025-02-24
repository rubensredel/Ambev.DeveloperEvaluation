using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleHandler : IRequestHandler<GetSaleCommand, GetSaleResponse>
{
    private readonly IMapper _mapper;
    private readonly ISalesRepository _salesRepository;

    public GetSaleHandler(ISalesRepository salesRepository, IMapper mapper)
    {
        _mapper = mapper;
        _salesRepository = salesRepository;
    }

    public async Task<GetSaleResponse> Handle(GetSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _salesRepository.GetByIdAsync(request.Id, cancellationToken);
        return _mapper.Map<GetSaleResponse>(sale);
    }
}
