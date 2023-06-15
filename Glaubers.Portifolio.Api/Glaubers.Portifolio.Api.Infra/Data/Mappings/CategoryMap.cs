using Microsoft.EntityFrameworkCore;
using Glaubers.Portifolio.Api.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Glaubers.Portifolio.Api.Infra.Data.Mappings
{
    public sealed class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            /* Table name and comments */
            builder.ToTable("TB_CATEGORY");

            /* Primary Keys */
            builder.HasKey(u => u.ID);

            /* Field names */
            builder.Property(u => u.ID).HasColumnName("ID");
            builder.Property(u => u.Name).HasColumnName("NAME");
            builder.Property(u => u.Description).HasColumnName("DESCRIPTION");
            builder.Property(u => u.Created).HasColumnName("CREATED");
            builder.Property(u => u.Deleted).HasColumnName("DELETED");
            builder.Property(u => u.LastUpdate).HasColumnName("LAST_UPDATE");

            /* Mandatory Fields */
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Description).IsRequired();
            builder.Property(u => u.Created).IsRequired();

            /* Nullable Fields*/
            builder.Property(u => u.LastUpdate).IsRequired(false);
            builder.Property(u => u.Deleted).IsRequired(false);

            /* Default Values */
            builder.Property(u => u.Created).HasDefaultValue(DateTime.Now);

            /* Field sizing */
            builder.Property(u => u.Name).HasMaxLength(40);
            builder.Property(u => u.Description).HasMaxLength(100);

            /* Query Filters */
            builder.HasQueryFilter(u => u.Deleted == null);

            /* Field lock */
            builder.Property(u => u.Created).ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        }
    }
}