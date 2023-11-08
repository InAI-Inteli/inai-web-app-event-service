using System;
using System.Collections.Generic;

namespace WebAPIEventService.Domain.Entities
{
    public partial class Anfitriao : BaseEntity
    {
        public int IdEvento { get; set; }
        public string? Nome { get; set; }
        public string? Imagem { get; set; }
        public string? Formacao { get; set; }
        public string? Descricao { get; set; }
        public string? RedeSocial { get; set; }
        public string? Profissao { get; set; }

        public virtual Evento IdEventoNavigation { get; set; } = null!;
    }
}
