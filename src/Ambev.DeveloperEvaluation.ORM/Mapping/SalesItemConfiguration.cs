using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SalesItemConfiguration : IEntityTypeConfiguration<SalesItem>
{
    public void Configure(EntityTypeBuilder<SalesItem> builder)
    {
        builder.ToTable("SalesItems");
        builder.Property(i => i.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(i => i.SalesId).HasColumnType("uuid").IsRequired();
        builder.Property(i => i.ProductId).HasColumnType("uuid").IsRequired();
        builder.Property(i => i.CreatedAt).IsRequired();
        builder.Property(i => i.UpdatedAt);
        builder.Property(i => i.Price).IsRequired();
        builder.Property(i => i.Quantity).IsRequired();
        builder.Property(i => i.Discount).IsRequired();
        builder.Property(i => i.Total).IsRequired();
        builder.Property(i => i.IsCanceled);
        builder
            .HasOne(i => i.Product)
            .WithOne()
            .HasForeignKey<SalesItem>(e => e.ProductId)
            .IsRequired();
    }
}
