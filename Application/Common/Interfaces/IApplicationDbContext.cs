using Domain.Entities;
using ETAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Categories> Categories { get; }

    DbSet<PaymentType> PaymentType { get; }

    DbSet<Expense> ExpenseEntries { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
