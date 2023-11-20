using MediatR;
using Application.Category.Queries;
using ETAPP.Application.Common.Mappings;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.PaymentMethod.Queries;

public class PaymentTypeDto : IMapFrom<PaymentTypes>
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class GetAllPaymentTypeQuery : IRequest<IEnumerable<PaymentTypeDto>>
{
}

public class GetAllPaymentTypeQueryHandler : IRequestHandler<GetAllPaymentTypeQuery, IEnumerable<PaymentTypeDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllPaymentTypeQueryHandler(IApplicationDbContext dbContext, IMapper mapper)    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public  async Task<IEnumerable<PaymentTypeDto>> Handle(GetAllPaymentTypeQuery query, CancellationToken cancellationToken)
    {
        var result = await _dbContext.PaymentType.ProjectToListAsync<PaymentTypeDto>(_mapper.ConfigurationProvider);

        return result;
    } 
}