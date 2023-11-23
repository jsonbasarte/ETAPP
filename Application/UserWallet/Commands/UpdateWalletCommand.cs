using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UserWallet.Commands;

public class UpdateWalletCommand : IRequest<bool>
{
    public int Id { get; set; }
    public decimal Balance { get; set; }
    public string Name { get; set; }
    public int UserId { get; set; }
    public WalletType Type { get; set; }
}

public class UpdateWalletCommandHandler : IRequestHandler<UpdateWalletCommand, bool>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateWalletCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }   

    public async Task<bool> Handle(UpdateWalletCommand request, CancellationToken cancellationToken)
    {
        var wallet = await _dbContext.Wallet.FirstAsync(w => w.Id == request.Id);

        wallet.Name = request.Name;
        wallet.Balance = request.Balance;
        wallet.Type = request.Type;
        wallet.UserId = request.UserId;

        _dbContext.Wallet.Add(wallet);

        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }
}
