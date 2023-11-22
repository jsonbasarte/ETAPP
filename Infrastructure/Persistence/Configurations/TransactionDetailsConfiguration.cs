using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class TransactionDetailsConfiguration : IEntityTypeConfiguration<TransactionDetails>
    {
        public void Configure(EntityTypeBuilder<TransactionDetails> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Description).IsRequired();
            builder.Property(e => e.Amount).HasColumnType("decimal(18,2)");
            builder.Property(e => e.Date).IsRequired();
            builder.HasOne<ApplicationUser>().WithMany().HasForeignKey(e => e.UserId);
            builder.HasOne(e => e.Category).WithMany().HasForeignKey(e => e.CategoryId);
            builder.HasOne(e => e.Wallet).WithMany().HasForeignKey(e => e.WalletId);
        }
    }
}
