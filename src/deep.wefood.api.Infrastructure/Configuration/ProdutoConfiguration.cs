using deep.wefood.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace deep.wefood.api.Infrastructure.Configuration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.ToTable("produtos");

            builder.HasKey(x => x.Id);

            //Foreign Key
            builder.HasOne(x => x.Empresa)
                .WithMany()
                .HasForeignKey(x => x.IdEmpresa);

            //Columms

            builder.Property(x => x.Id)
                .HasColumnName("prod_id")
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("prod_nome");

            builder.Property(x => x.IdEmpresa)
                .HasColumnName("prod_emp_id")
                .IsRequired();

            builder.Property(x => x.Guid)
                .HasColumnName("prod_guid")
                .IsRequired()
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(x => x.Descricao)
                .HasColumnName("prod_desc");

            builder.Property(x => x.DataCadastro)
               .HasColumnName("prod_dt_cadastro")
               .IsRequired()
               .HasDefaultValueSql("now()");


        }

    }
}
