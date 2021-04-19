using deep.wefood.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace deep.wefood.api.Infrastructure.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductDetail>
    {

        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {

            builder.ToTable("products");

            builder.HasKey(x => x.Id);

            //Foreign Keys
            builder.HasMany(x => x.ComplementGroups)
                .WithOne()
                .HasForeignKey(x => x.IdProduct);

            //Columms
            builder.Property(x => x.Id)
                .HasColumnName("prod_id")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("prod_name");

            builder.Property(x => x.IdCompany)
                .HasColumnName("prod_cmp_id")
                .IsRequired();

            builder.Property(x => x.Price)
                .HasColumnName("prod_price")
                .IsRequired();

            builder.Property(x => x.Guid)
                .HasColumnName("prod_guid")
                .IsRequired()
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(x => x.DiscountPrice)
                .HasColumnName("prod_discount");

            builder.Property(x => x.Description)
                .HasColumnName("prod_desc");

            builder.Property(x => x.RegisterDate)
               .HasColumnName("prod_dt_register")
               .IsRequired()
               .HasDefaultValueSql("now()");


        }

    }
}
