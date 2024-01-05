using Application.Common.Interfaces;
using Domain.Entities;
using ETAPP.Application.Common.Interfaces;
using MediatR;

namespace Application.UserWallet.Commands;

public class CreateWalletCommand : IRequest<int>
{
    public decimal Balance { get; set; }
    public string Name { get; set; }
    public WalletType Type { get; set; }
}

public class CreateWalletCommandHandler : IRequestHandler<CreateWalletCommand, int>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IUserContext _userContext;

    public CreateWalletCommandHandler(IApplicationDbContext dbContext, IUserContext userContext)
    {
        _dbContext = dbContext;
        _userContext = userContext;
    }

    public async Task<int> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
    {
        var userId = _userContext.UserId!.Value;

        var wallet = new Wallet
        {
            UserId = userId,
            Balance = request.Balance,
            Name = request.Name,
            Type = request.Type
        };

        _dbContext.Wallet.Add(wallet);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return wallet.Id;
    }
}
