using System;
using System.Collections.Generic;

namespace WebAPIEventService.Domain.Entities
{
    public partial class Evento : BaseEntity
    {
        public Evento()
        {
            Anfitrioes = new HashSet<Anfitriao>();
            Inscricoes = new HashSet<Inscricao>();
        }

        public string? Nome { get; set; }
        public DateOnly? Data { get; set; }
        public string? Tipo { get; set; }
        public string? Local { get; set; }
        public string? Descricao { get; set; }
        public string? Imagem { get; set; }
        public TimeOnly? Hora { get; set; }
        public TimeOnly? Duracao { get; set; }
        public bool? Externo { get; set; }
        public string? Sobre { get; set; }

        public virtual ICollection<Anfitriao> Anfitrioes { get; set; }
        public virtual ICollection<Inscricao> Inscricoes { get; set; }
    }
}
