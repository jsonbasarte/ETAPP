
using Application.Common.Interfaces;
using Domain.Entities;
using ETAPP.Domain.Entities;
using ETAPP.Infrastructure.Identity;
using Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>, IApplicationDbContext
    {
        private readonly IMediator _mediator;
          public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        public virtual DbSet<ExpenseEntry> ExpenseEntries => Set<ExpenseEntry>();
        public DbSet<Categories> Categories => Set<Categories>();
        public DbSet<PaymentType> PaymentType => Set<PaymentType>();

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            SeedRoles(modelBuilder);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            //The seed entity for entity type 'ApplicationRole' cannot be added because a non - zero value 
            //is required for property 'Id'.Consider providing a negative value to avoid collisions with non - seed data.
            builder.Entity<ApplicationRole>().HasData(
                    new ApplicationRole() { Id = -1, Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                    new ApplicationRole() { Id = -2, Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }
            );
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEvents(this);

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
