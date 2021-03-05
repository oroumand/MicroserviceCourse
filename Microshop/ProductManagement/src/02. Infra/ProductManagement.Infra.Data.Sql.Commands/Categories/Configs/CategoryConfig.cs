using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Core.Domain.Categories.Entities;
using Zamin.Core.Domain.Toolkits.ValueObjects;

namespace ProductManagement.Infra.Data.Sql.Commands.Categories.Configs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Title).HasConversion(c => c.Value, c => Title.FromString(c)).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Disabled).HasDefaultValue(false);
            builder.HasMany(c => c.Children).WithOne().HasForeignKey(c => c.ParentId).OnDelete(DeleteBehavior.NoAction);
            builder.HasIndex(c => new { c.ParentId, c.Title }).IsUnique();
            builder.HasIndex(c => c.BusinessId).IsUnique();
        }
    }
}
