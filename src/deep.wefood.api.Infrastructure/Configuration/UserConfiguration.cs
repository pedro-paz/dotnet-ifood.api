using deep.wefood.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace deep.wefood.api.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(x => x.Id);

            //Foreign Key
            builder.HasMany(x => x.Orders)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.IdUser);

            //Columns
            builder.Property(x => x.Id)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(x => x.Guid)
              .HasColumnName("user_guid")
              .IsRequired()
              .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(x => x.Name)
                .HasColumnName("user_name")
                .IsRequired();

            builder.Property(x => x.Password)
               .HasColumnName("user_password")
               .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("user_email")
                .IsRequired();

            builder.Property(x => x.RegisterDate)
               .HasColumnName("user_dt_register")
               .IsRequired()
               .HasDefaultValueSql("now()");


        }
    }
}