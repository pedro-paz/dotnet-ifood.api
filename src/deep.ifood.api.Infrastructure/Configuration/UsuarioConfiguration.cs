using deep.ifood.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace deep.ifood.api.Infrastructure.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("usuarios");

            builder.HasKey(x => x.Id);

            //Foreign Key
            builder.HasOne(x => x.Empresa)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(x => x.IdEmpresa);

            //Columns
            builder.Property(x => x.Id)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(x => x.Guid)
              .HasColumnName("user_guid")
              .IsRequired()
              .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(x => x.IdEmpresa)
               .HasColumnName("user_emp_id")
               .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("user_nome")
                .IsRequired();

            builder.Property(x => x.Senha)
               .HasColumnName("user_senha")
               .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("user_email")
                .IsRequired();

            builder.Property(x => x.DataCadastro)
               .HasColumnName("user_dt_cadastro")
               .IsRequired()
               .HasDefaultValueSql("now()");


        }
    }
}