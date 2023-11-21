using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class UserWalletConfiguration : IEntityTypeConfiguration<UserWallet>
{
    public void Configure(EntityTypeBuilder<UserWallet> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Balance).HasColumnType("decimal(18,2)");
        builder.HasOne<ApplicationUser>().WithMany().HasForeignKey(d => d.UserId);
        builder.HasOne(u => u.Wallet).WithMany().HasForeignKey(u => u.WalletId);
        builder.Property(u => u.WalletType);
    }
}
