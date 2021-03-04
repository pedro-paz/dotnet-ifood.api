using deep.wefood.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace deep.wefood.api.Infrastructure.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.ToTable("products");

            builder.HasKey(x => x.Id);

            //Foreign Keys
            builder.HasMany(x => x.Ingredients)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.IdProduct);

            builder.HasOne(x => x.Company)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.IdCompany);

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

            builder.Property(x => x.Description)
                .HasColumnName("prod_desc");

            builder.Property(x => x.RegisterDate)
               .HasColumnName("prod_dt_register")
               .IsRequired()
               .HasDefaultValueSql("now()");


        }

    }
}
