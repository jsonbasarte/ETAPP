using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.PaymentType.Commands;

public class UpdatePaymentTypeCommand : IRequest<bool>
{
    public int Id { get; set;}
    public string Name { get; set;}
}

public class UpdatePaymentTypeCommandHandler : IRequestHandler<UpdatePaymentTypeCommand, bool>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdatePaymentTypeCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Handle(UpdatePaymentTypeCommand request, CancellationToken cancellationToken)
    {
        var paymentType = await _dbContext.PaymentType.FirstAsync(p => p.Id == request.Id);

        paymentType.Name = request.Name;

        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }
}