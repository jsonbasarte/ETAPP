using ETAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Categories> Categories { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
