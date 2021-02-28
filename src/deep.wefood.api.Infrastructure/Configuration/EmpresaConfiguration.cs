using deep.wefood.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace deep.wefood.api.Infrastructure.Configuration
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("empresas");

            builder.HasKey(x => x.Id);

            //Columns
            builder.Property(x => x.Id)
                .HasColumnName("emp_id")
                .IsRequired();

            builder.Property(x => x.Guid)
                .HasColumnName("emp_guid")
                .IsRequired()
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(x => x.Nome)
                .HasColumnName("emp_nome")
                .IsRequired();

            builder.Property(x => x.DataCadastro)
               .HasColumnName("emp_dt_cadastro")
               .IsRequired()
               .HasDefaultValueSql("now()");
        }
    }
}
