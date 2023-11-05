using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPIEventService.Domain.Entities;

namespace WebAPIEventService.Infra.Data.Mappings
{
    public class InscricaoConfiguration : IEntityTypeConfiguration<Inscricao>
    {
        public void Configure(EntityTypeBuilder<Inscricao> builder)
        {
            builder.ToTable("inscricoes");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone").HasColumnName("created_at");
            builder.Property(e => e.Curso).HasColumnType("character varying").HasColumnName("curso");
            builder.Property(e => e.Email).HasColumnType("character varying").HasColumnName("email");
            builder.Property(e => e.IdEvento).HasColumnName("id_evento");
            builder.Property(e => e.InstituicaoEnsino).HasColumnType("character varying").HasColumnName("instituicao_ensino");
            builder.Property(e => e.Nome).HasColumnType("character varying").HasColumnName("nome");
            builder.Property(e => e.Profissao).HasColumnType("character varying").HasColumnName("profissao");
            builder.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone").HasColumnName("updated_at");

            builder.HasOne(d => d.IdEventoNavigation)
                .WithMany(p => p.Inscricoes)
                .HasForeignKey(d => d.IdEvento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_evento");
        }
    }
}
