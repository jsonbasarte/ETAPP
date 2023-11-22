using Domain.Entities;
using ETAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Categories> Categories { get; }

    DbSet<TransactionDetails> TransactionDetails { get; }

    DbSet<Wallet> Wallet { get;  }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
