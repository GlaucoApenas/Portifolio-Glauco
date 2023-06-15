using Microsoft.EntityFrameworkCore;
using Glaubers.Portifolio.Api.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Glaubers.Portifolio.Api.Infra.Data.Mappings
{
    public sealed class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            /* Table name and comments */
            builder.ToTable("TB_POST");

            /* Primary Keys */
            builder.HasKey(u => u.ID);

            /* Field names */
            builder.Property(u => u.ID).HasColumnName("ID");
            builder.Property(u => u.Title).HasColumnName("TITLE");
            builder.Property(u => u.Description).HasColumnName("DESCRIPTION");
            builder.Property(u => u.Body).HasColumnName("BODY");
            builder.Property(u => u.UserID).HasColumnName("USER_ID");
            builder.Property(u => u.CategoryID).HasColumnName("CATEGORY_ID");
            builder.Property(u => u.Created).HasColumnName("CREATED");
            builder.Property(u => u.Deleted).HasColumnName("DELETED");
            builder.Property(u => u.LastUpdate).HasColumnName("LAST_UPDATE");

            /* Ignoring */
            builder.Ignore(l => l.User);
            builder.Ignore(l => l.Category);

            /* Mandatory Fields */
            builder.Property(u => u.Title).IsRequired();
            builder.Property(u => u.Description).IsRequired();
            builder.Property(u => u.UserID).IsRequired();
            builder.Property(u => u.Created).IsRequired();

            /* Nullable Fields*/
            builder.Property(u => u.LastUpdate).IsRequired(false);
            builder.Property(u => u.Deleted).IsRequired(false);

            /* Default Values */
            builder.Property(u => u.Created).HasDefaultValue(DateTime.Now);

            /* Field sizing */
            builder.Property(u => u.Title).HasMaxLength(30);
            builder.Property(u => u.Description).HasMaxLength(100);
            builder.Property(u => u.Body).HasMaxLength(2000);

            /* Query Filters */
            builder.HasQueryFilter(u => u.Deleted == null);

            /* ForeignKey Fields */
            builder.HasOne(u => u.User).WithMany().HasForeignKey(p => p.UserID);
            builder.HasOne(u => u.Category).WithOne().HasForeignKey<Post>(p=> p.CategoryID);

            /* Field lock */
            builder.Property(u => u.Created).ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        }
    }
}