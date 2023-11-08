using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebAPIEventService.Domain.Entities;

namespace WebAPIEventService.Infra.Data.Mappings
{
    public class AnfitriaoConfiguration : IEntityTypeConfiguration<Anfitriao>
    {
        public void Configure(EntityTypeBuilder<Anfitriao> builder)
        {
            builder.ToTable("anfitrioes");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone").HasColumnName("created_at");
            builder.Property(e => e.Descricao).HasColumnType("character varying").HasColumnName("descricao");
            builder.Property(e => e.Formacao).HasColumnType("character varying").HasColumnName("formacao");
            builder.Property(e => e.IdEvento).HasColumnName("id_evento");
            builder.Property(e => e.Imagem).HasColumnType("character varying").HasColumnName("imagem");
            builder.Property(e => e.Nome).HasColumnType("character varying").HasColumnName("nome");
            builder.Property(e => e.Profissao).HasColumnType("character varying").HasColumnName("profissao");
            builder.Property(e => e.RedeSocial).HasColumnType("character varying").HasColumnName("rede_social");
            builder.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone").HasColumnName("updated_at");

            builder.HasOne(d => d.IdEventoNavigation)
                .WithMany(p => p.Anfitrioes)
                .HasForeignKey(d => d.IdEvento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_evento");
        }
    }
}
