using deep.wefood.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace deep.wefood.api.Infrastructure.Configuration
{
    public class ComplementConfiguration : IEntityTypeConfiguration<Complement>
    {
        public void Configure(EntityTypeBuilder<Complement> builder)
        {
            builder.ToTable("complement");

            builder.HasKey(x => x.Id);

            //Columns
            builder.Property(x => x.Guid)
              .HasColumnName("compl_guid")
              .IsRequired()
              .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(x => x.Id)
                .HasColumnName("compl_id")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("compl_name")
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnName("compl_desc")
                .IsRequired();

            builder.Property(x => x.RegisterDate)
               .HasColumnName("compl_dt_register")
               .IsRequired()
               .HasDefaultValueSql("now()");
        }
    }
}
