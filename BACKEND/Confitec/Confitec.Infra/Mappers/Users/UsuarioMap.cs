using Confitec.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Infra.Mappers.Users
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Nome).HasColumnName("Nome").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Sobrenome).HasColumnName("Sobrenome").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(100).IsRequired();
            builder.Property(x => x.DataNascimento).HasColumnName("Datanascimento").IsRequired();
            builder.Property(x => x.EscolaridadeId).HasColumnName("Escolaridade_id").IsRequired();
            builder.HasOne(x => x.Escolaridade).WithOne().HasForeignKey<Escolaridade>(x => x.Id);
        }
    }
}
