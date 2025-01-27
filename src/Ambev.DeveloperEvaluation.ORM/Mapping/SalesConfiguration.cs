using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SalesConfiguration : IEntityTypeConfiguration<Sales>
{
    public void Configure(EntityTypeBuilder<Sales> builder)
    {
        builder.ToTable("Sales");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(s => s.Number).IsRequired().ValueGeneratedOnAdd();
        builder.Property(s => s.CreatedAt).IsRequired();
        builder.Property(s => s.UpdatedAt);
        builder.Property(s => s.Customer).IsRequired().HasMaxLength(100);
        builder.Property(s => s.Total).IsRequired();
        builder.Property(s => s.Branch).IsRequired().HasMaxLength(100);
        builder.Property(s => s.IsCanceled);
        builder
            .HasMany(s => s.Items)
            .WithOne(x => x.Sales)
            .HasForeignKey(i => i.SalesId);
    }
}
