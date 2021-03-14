using deep.wefood.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace deep.wefood.api.Infrastructure.Configuration
{
    public class ComplementGroupConfiguration : IEntityTypeConfiguration<ComplementGroup>
    {

        public void Configure(EntityTypeBuilder<ComplementGroup> builder)
        {

            builder.ToTable("complements_group");

            builder.HasKey(x => x.Id);

            //Foreign Keys
            builder.HasMany(x => x.Complements)
                .WithOne()
                .HasForeignKey(x => x.IdComplementGroup);

            //Columms
            builder.Property(x => x.Id)
                .HasColumnName("cgroup_id")
                .IsRequired();

            builder.Property(x => x.IdProduct)
                .HasColumnName("cgroup_prod_id")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("cgroup_name")
                .IsRequired();

            builder.Property(x => x.Guid)
                .HasColumnName("cgroup_guid")
                .IsRequired()
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(x => x.Minimum)
                .HasColumnName("cgroup_min")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(x => x.Maximum)
                .HasColumnName("cgroup_max")
                .IsRequired()
                .HasDefaultValue(10);

            builder.Property(x => x.RegisterDate)
               .HasColumnName("cgroup_dt_register")
               .IsRequired()
               .HasDefaultValueSql("now()");

        }
    }
}
