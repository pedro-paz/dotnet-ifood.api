using deep.ifood.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace deep.ifood.api.Infrastructure.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("clientes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("cli_id")
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("cli_nome")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("cli_email")
                .IsRequired();

            builder.Property(x => x.DataCadastro)
               .HasColumnName("cli_dt_cadastro")
               .IsRequired()
               .HasDefaultValueSql("now()");
        }
    }
}
