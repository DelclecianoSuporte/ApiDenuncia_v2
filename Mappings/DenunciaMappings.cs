using ApiDenuncia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDenuncia.Mappings
{
    public class DenunciaMappings : IEntityTypeConfiguration<Denuncia>
    {
        public void Configure(EntityTypeBuilder<Denuncia> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Numero_Protocolo)
                .IsRequired();

            builder.Property(d => d.Data_Protocolo);

            builder.Property(d => d.Mensagem);

            builder.Property(d => d.Status);

            builder.Property(d => d.Resposta);

            builder.ToTable("Protocolo");
        }
    }
}
