using deep.wefood.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace deep.wefood.api.Infrastructure.Configuration
{
    public class ProductOrderConfiguration : IEntityTypeConfiguration<ProductOrder>
    {
        public void Configure(EntityTypeBuilder<ProductOrder> builder)
        {

            builder.ToTable("order_products");
            builder.HasKey(x => x.Id);

            //Foreign Key
            builder.HasOne(x => x.Order)
                .WithMany(x => x.ProductOrder)
                .HasForeignKey(x => x.IdOrder);

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.IdProduct);

            //Columns
            builder.Property(x => x.Id)
                .HasColumnName("ordprod_id")
                .IsRequired();

            builder.Property(x => x.RegisterDate)
                .HasColumnName("ordprod_dt_register")
                .IsRequired()
                .HasDefaultValueSql("now()");

            builder.Property(x => x.IdProduct)
                .HasColumnName("ordprod_prod_id")
                .IsRequired();

            builder.Property(x => x.IdOrder)
                .HasColumnName("ordprod_ped_id")
                .IsRequired();

            builder.Property(x => x.Price)
                .HasColumnName("ordprod_price")
                .IsRequired();


        }
    }
}
