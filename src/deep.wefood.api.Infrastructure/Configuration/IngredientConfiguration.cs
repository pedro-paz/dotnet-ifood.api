using deep.wefood.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace deep.wefood.api.Infrastructure.Configuration
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable("ingredients");

            builder.HasKey(x => x.Id);

            //Foreign Keys
            builder.HasOne(x => x.Company)
                .WithMany()
                .HasForeignKey(x => x.IdCompany);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Ingredients)
                .HasForeignKey(x => x.IdProduct);

            //Columns
            builder.Property(x => x.Guid)
              .HasColumnName("ing_guid")
              .IsRequired()
              .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(x => x.Id)
                .HasColumnName("ing_id")
                .IsRequired();

            builder.Property(x => x.IdProduct)
                .HasColumnName("ing_prodid")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("ing_name")
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnName("ing_desc")
                .IsRequired();

            builder.Property(x => x.IdCompany)
                .HasColumnName("ing_cmp_id")
                .IsRequired();

            builder.Property(x => x.RegisterDate)
               .HasColumnName("ing_dt_register")
               .IsRequired()
               .HasDefaultValueSql("now()");
        }
    }
}
