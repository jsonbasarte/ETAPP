using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using ETAPP.Application.Common.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public GetAllWalletQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetAllWalletQueryDto>> Handle(GetAllWalletQuery request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Wallet.ProjectToListAsync<GetAllWalletQueryDto>(_mapper.ConfigurationProvider);

        var list = new List<GetAllWalletQueryDto>();

        foreach (var item in result)
        {
            var type = (WalletType)item.Type;
            list.Add(new GetAllWalletQueryDto() { Id = item.Id, Balance = item.Balance, Name = item.Name, TypeName = type.ToString() });
        }
        return result;
    }
}