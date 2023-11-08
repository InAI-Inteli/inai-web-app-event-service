using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebAPIEventService.Domain.Entities;

namespace WebAPIEventService.Infra.Data.Mappings
{
    public class EventoConfiguration : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable("eventos");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone").HasColumnName("created_at");
            builder.Property(e => e.Data).HasColumnName("data");
            builder.Property(e => e.Descricao).HasColumnType("character varying").HasColumnName("descricao");
            builder.Property(e => e.Duracao).HasColumnName("duracao");
            builder.Property(e => e.Externo).HasColumnName("externo");
            builder.Property(e => e.Hora).HasColumnName("hora");
            builder.Property(e => e.Imagem).HasColumnType("character varying").HasColumnName("imagem");
            builder.Property(e => e.Local).HasColumnType("character varying").HasColumnName("local");
            builder.Property(e => e.Nome).HasColumnType("character varying").HasColumnName("nome");
            builder.Property(e => e.Sobre).HasColumnType("character varying").HasColumnName("sobre");
            builder.Property(e => e.Tipo).HasColumnType("character varying").HasColumnName("tipo");
            builder.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone").HasColumnName("updated_at");
        }
    }
}
