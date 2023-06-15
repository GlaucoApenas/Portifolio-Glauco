using Microsoft.EntityFrameworkCore;
using Glaubers.Portifolio.Api.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Glaubers.Portifolio.Api.Infra.Data.Mappings
{
    public sealed class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            /* Table name and comments */
            builder.ToTable("TB_USER");

            /* Primary Keys */
            builder.HasKey(u => u.ID);

            /* Field names */
            builder.Property(u => u.ID).HasColumnName("ID");
            builder.Property(u => u.Nickname).HasColumnName("NICKNAME");
            builder.Property(u => u.Email).HasColumnName("EMAIL");
            builder.Property(u => u.Password).HasColumnName("PASSWORD");
            builder.Property(u => u.Birth).HasColumnName("BIRTH");
            builder.Property(u => u.UserType).HasColumnName("USER_TYPE");
            builder.Property(u => u.Created).HasColumnName("CREATED");
            builder.Property(u => u.Deleted).HasColumnName("DELETED");
            builder.Property(u => u.LastUpdate).HasColumnName("LAST_UPDATE");

            /* Ignoring */
            builder.Ignore(l => l.Age);

            /* Mandatory Fields */
            builder.Property(u => u.Nickname).IsRequired();
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.Birth).IsRequired();
            builder.Property(u => u.UserType).IsRequired();
            builder.Property(u => u.Created).IsRequired();

            /* Nullable Fields*/
            builder.Property(u => u.LastUpdate).IsRequired(false);
            builder.Property(u => u.Deleted).IsRequired(false);

            /* Default Values */
            builder.Property(u => u.Created).HasDefaultValue(DateTime.Now);

            /* Field sizing */
            builder.Property(u => u.Nickname).HasMaxLength(30);
            builder.Property(u => u.Email).HasMaxLength(100);

            /* Query Filters */
            builder.HasQueryFilter(u => u.Deleted == null);

            /* ForeignKey Fields */
            //builder.HasMany(u => u.Posts).WithOne(p => p.User).HasForeignKey(p => p.UserID);

            /* Field lock */
            builder.Property(u => u.Created).ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        }
    }
}