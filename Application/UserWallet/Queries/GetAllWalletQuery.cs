using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using ETAPP.Application.Common.Interfaces;
using ETAPP.Application.Common.Mappings;
using MediatR;

namespace Application.UserWallet.Queries;

public class GetAllWalletQueryDto : IMapFrom<Wallet>
{
    public int Id { get; set; }
    public decimal Balance { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = null;
    public int Type { get; set; }
    public string TypeName { get; set; }
}

public class GetAllWalletQuery : IRequest<IEnumerable<GetAllWalletQueryDto>> {}

public class GetAllWalletQueryHandler : IRequestHandler<GetAllWalletQuery, IEnumerable<GetAllWalletQueryDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public GetAllWalletQueryHandler(IApplicationDbContext dbContext, IMapper mapper, ICurrentUserService currentUserService, IUserContext userContext)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _userContext = userContext;
    }

    public async Task<IEnumerable<GetAllWalletQueryDto>> Handle(GetAllWalletQuery request, CancellationToken cancellationToken)
    {
        var userId = _userContext.UserId!.Value;

        var result = await _dbContext.Wallet
                .Where(d => d.UserId == userId)
                    .ProjectToListAsync<GetAllWalletQueryDto>(_mapper.ConfigurationProvider);

        return result;
    }
}