using deep.wefood.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace deep.wefood.api.Infrastructure.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders");

            builder.HasKey(x => x.Id);

            //Foreign Keys
            builder.HasOne(x => x.User)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.IdUser);

            builder.HasMany(x => x.ProductOrder)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.IdOrder);

            //Columns
            builder.Property(x => x.Id)
                .HasColumnName("ord_id")
                .IsRequired();

            builder.Property(x => x.Guid)
                .HasColumnName("ord_guid")
                .IsRequired()
                .HasDefaultValueSql("uuid_generate_v4()");


            builder.Property(x => x.IdUser)
                .HasColumnName("ord_user_id")
                .IsRequired();

            builder.Property(x => x.RegisterDate)
                .HasColumnName("ord_dt_register")
                .IsRequired()
                .HasDefaultValueSql("now()");





        }
    }
}
