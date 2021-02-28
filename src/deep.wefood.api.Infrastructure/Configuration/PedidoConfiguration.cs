using deep.wefood.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace deep.wefood.api.Infrastructure.Configuration
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Order>
    {

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("pedidos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ped_id")
                .IsRequired();

            builder.Property(x => x.DataCadastro)
                .HasColumnName("ped_dt_cadastro")
                .IsRequired()
                .HasDefaultValueSql("now()");

            builder.Property(x => x.IdCliente)
                .HasColumnName("ped_cli_id")
                .IsRequired();

            builder.HasOne(x => x.Cliente).WithMany()
                .HasForeignKey(x => x.IdCliente);

            builder.HasMany(x => x.PedidoProdutos)
                .WithOne(x => x.Pedido)
                .HasForeignKey(x => x.IdPedido);

        }
    }
}
