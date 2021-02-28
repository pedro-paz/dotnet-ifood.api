using deep.wefood.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace deep.wefood.api.Infrastructure.Configuration
{
    public class PedidoProdutosConfiguration : IEntityTypeConfiguration<ProductOrder>
    {
        public void Configure(EntityTypeBuilder<ProductOrder> builder)
        {

            builder.ToTable("pedido_produtos");
            builder.HasKey(x => x.Id);

            //Foreign Key

            //Columns

            builder.Property(x => x.Id)
                .HasColumnName("pedprod_id")
                .IsRequired();

            builder.Property(x => x.IdProduto)
                .HasColumnName("pedprod_prod_id")
                .IsRequired();

            builder.Property(x => x.IdPedido)
                .HasColumnName("pedprod_ped_id")
                .IsRequired();

            //Foreign Key

            builder.HasOne(x => x.Pedido)
                .WithMany(x => x.PedidoProdutos)
                .HasForeignKey(x => x.IdPedido);

            builder.HasOne(x => x.Produto)
                .WithMany()
                .HasForeignKey(x => x.IdProduto);

            builder.Property(x => x.DataCadastro)
               .HasColumnName("pedprod_dt_cadastro")
               .IsRequired()
               .HasDefaultValueSql("now()");
        }
    }
}
