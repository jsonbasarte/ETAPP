using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.PaymentType.Commands;

public class DeletePaymentTypeCommand : IRequest<(bool State, string Message)>
{
    public int Id { get; set; }
}

public class DeletePaymentTypeCommandHandler : IRequestHandler<DeletePaymentTypeCommand, (bool State, string Message)>
{
    private readonly IApplicationDbContext _dbContext;

    public DeletePaymentTypeCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<(bool State, string Message )> Handle(DeletePaymentTypeCommand request, CancellationToken cancellationToken)
    {
        var paymentType = await _dbContext.PaymentType.FirstAsync(p => p.Id == request.Id);

        _dbContext.PaymentType.Remove(paymentType);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return (true, "OK");
    }
}