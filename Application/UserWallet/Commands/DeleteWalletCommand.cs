using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UserWallet.Commands;

public class DeleteWalletCommand : IRequest<(bool State, string Message)>
{
    public int Id { get; set; }
}

public class DeleteWalletCommandHandler : IRequestHandler<DeleteWalletCommand, (bool State, string Message)>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteWalletCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<(bool State, string Message)> Handle(DeleteWalletCommand request, CancellationToken cancellationToken)
    {
        var wallet = await _dbContext.Wallet.FirstAsync(w => w.Id == request.Id);

        _dbContext.Wallet.Remove(wallet);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return (true, "Ok");
    }
}
