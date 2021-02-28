using deep.wefood.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace deep.wefood.api.Infrastructure.Configuration
{
    public class IngredienteConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable("ingredientes");

            builder.HasKey(x => x.Id);

            //Foreign Key
            builder.HasOne(x => x.Empresa)
                .WithMany()
                .HasForeignKey(x => x.IdEmpresa);

            builder.HasOne(x => x.Produto)
                .WithMany(x => x.Ingredientes)
                .HasForeignKey(x => x.IdProduto);

            //Columns
            builder.Property(x => x.Guid)
              .HasColumnName("ing_guid")
              .IsRequired()
              .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(x => x.Id)
                .HasColumnName("ing_id")
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("ing_nome")
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnName("ing_desc")
                .IsRequired();

            builder.Property(x => x.IdEmpresa)
                .HasColumnName("ing_emp_id")
                .IsRequired();

            builder.Property(x => x.DataCadastro)
               .HasColumnName("ing_dt_cadastro")
               .IsRequired()
               .HasDefaultValueSql("now()");
        }
    }
}
