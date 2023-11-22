using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
{
    public void Configure(EntityTypeBuilder<Wallet> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Balance).HasColumnType("decimal(18,2)");
        builder.HasOne<ApplicationUser>().WithMany().HasForeignKey(d => d.UserId);
        builder.Property(u => u.Name).HasMaxLength(200);
        builder.Property(u => u.Type).HasMaxLength(7);
    }
}