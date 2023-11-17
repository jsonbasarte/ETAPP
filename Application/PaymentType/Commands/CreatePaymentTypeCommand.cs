using Application.Common.Interfaces;
using Domain.Entities;
using ETAPP.Domain.Entities;
using MediatR;

namespace Application.PaymentMethod.Commands;

public class CreatePaymentTypeCommand : IRequest<int>
{
    public string Name { get; set; } = null;
}

public class CreatePaymentTypeCommandHandler : IRequestHandler<CreatePaymentTypeCommand, int>
{
    private readonly IApplicationDbContext _dbContext;

    public CreatePaymentTypeCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(CreatePaymentTypeCommand request, CancellationToken cancellationToken)
    {
        var paymentType = new PaymentType { Name = request.Name };
        
        _dbContext.PaymentType.Add(paymentType);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return 1;
    }
}

