using deep.wefood.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace deep.wefood.api.Infrastructure.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("companies");

            builder.HasKey(x => x.Id);

            //Foreign Keys
            builder.HasMany(x => x.Products)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.IdCompany);

            //Columns
            builder.Property(x => x.Id)
                .HasColumnName("cmp_id")
                .IsRequired();

            builder.Property(x => x.Guid)
                .HasColumnName("cmp_guid")
                .IsRequired()
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(x => x.Zip)
                .HasColumnName("cmp_zip")
                .IsRequired();

            builder.Property(x => x.Street)
                .HasColumnName("cmp_street")
                .IsRequired();

            builder.Property(x => x.City)
                .HasColumnName("cmp_city")
                .IsRequired();

            builder.Property(x => x.State)
                .HasColumnName("cmp_state")
                .IsRequired();

            builder.Property(x => x.StreetNumber)
                .HasColumnName("cmp_street_number")
                .IsRequired();

            builder.Property(x => x.District)
                .HasColumnName("cmp_district")
                .IsRequired();

            builder.Property(x => x.Rating)
                .HasColumnName("cmp_rating")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(x => x.MinimumOrderValue)
                .HasColumnName("cmp_min_order")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("cmp_name")
                .IsRequired();

            builder.Property(x => x.RegisterDate)
               .HasColumnName("cmp_dt_register")
               .IsRequired()
               .HasDefaultValueSql("now()");
        }
    }
}
