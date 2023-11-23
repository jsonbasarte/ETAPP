using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.UserWallet.Commands;

public class CreateWalletCommand : IRequest<int>
{
    public decimal Balance { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public WalletType Type { get; set; }
}

public class CreateWalletCommandHandler : IRequestHandler<CreateWalletCommand, int>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateWalletCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
    {
        var wallet = new Wallet
        {
            Balance = request.Balance,
            UserId = request.UserId,
            Name = request.Name,
            Type = request.Type
        };

        _dbContext.Wallet.Add(wallet);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return wallet.Id;
    }
}
