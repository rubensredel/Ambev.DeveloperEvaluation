using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleHandler : IRequestHandler<GetSaleCommand, GetSaleResult>
{
    private readonly IMapper _mapper;
    private readonly ISalesRepository _salesRepository;

    public GetSaleHandler(ISalesRepository salesRepository, IMapper mapper)
    {
        _mapper = mapper;
        _salesRepository = salesRepository;
    }

    public async Task<GetSaleResult> Handle(GetSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _salesRepository.GetByIdAsync(request.Id, cancellationToken);
        return sale == null ? throw new KeyNotFoundException($"Sales with ID {request.Id} not found") : _mapper.Map<GetSaleResult>(sale);
    }
}
