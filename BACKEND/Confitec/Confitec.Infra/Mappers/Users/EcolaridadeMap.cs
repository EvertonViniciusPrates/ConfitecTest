using Confitec.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confitec.Infra.Mappers.Users
{
    public class EcolaridadeMap : IEntityTypeConfiguration<Escolaridade>
    {
        public void Configure(EntityTypeBuilder<Escolaridade> builder)
        {
            builder.ToTable("Escolaridade", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Descricao).HasColumnName("Descricao").HasMaxLength(20);
        }
    }
}
