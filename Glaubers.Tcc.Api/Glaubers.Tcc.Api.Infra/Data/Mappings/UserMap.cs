using Microsoft.EntityFrameworkCore;
using Glaubers.Tcc.Api.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Glaubers.Tcc.Api.Infra.Data.Mappings
{
    public sealed class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            /* Table name and comments */
            builder.ToTable("TB_USER").HasComment("Users");

            /* Primary Keys */
            builder.HasKey(c => c.ID);

            /* Field names */
            builder.Property(c => c.ID).HasColumnName("USER_ID");
            builder.Property(c => c.FirstName).HasColumnName("USER_FIRSTNAME");
            builder.Property(c => c.LastName).HasColumnName("USER_LASTNAME");
            builder.Property(c => c.Birth).HasColumnName("USER_BIRTH");
            builder.Property(c => c.UserType).HasColumnName("USER_TYPE");
            builder.Property(c => c.Created).HasColumnName("CREATED");
            builder.Property(c => c.Enabled).HasColumnName("ENABLED");

            /* Ignoring */
            //builder.Ignore(l => l.IsValid);
            //builder.Ignore(l => l.Notifications);

            /* Mandatory Fields */
            builder.Property(c => c.FirstName).IsRequired();
            builder.Property(c => c.LastName).IsRequired();
            builder.Property(c => c.Birth).IsRequired();
            builder.Property(c => c.UserType).IsRequired();
            builder.Property(c => c.Created).IsRequired();
            builder.Property(c => c.Enabled).IsRequired();

            /* Default Values */
            builder.Property(c => c.Enabled).HasDefaultValue(true);
            builder.Property(c => c.Created).HasDefaultValue(DateTime.Now);

            /* Field sizing */
            builder.Property(c => c.FirstName).HasMaxLength(100);
            builder.Property(c => c.LastName).HasMaxLength(100);

            /* Query Filters */
            builder.HasQueryFilter(c => c.Enabled);

            /* Field lock */
            builder.Property(c => c.Created).ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        }
    }
}