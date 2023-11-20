using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class PaymentTypeConfiguration : IEntityTypeConfiguration<PaymentTypes>
{
    public void Configure(EntityTypeBuilder<PaymentTypes> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(200);
    }
}
