using System;
using System.Collections.Generic;

namespace WebAPIEventService.Domain.Entities
{
    public partial class Inscricao : BaseEntity
    {
        public int IdEvento { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? InstituicaoEnsino { get; set; }
        public string? Curso { get; set; }
        public string? Profissao { get; set; }

        public virtual Evento IdEventoNavigation { get; set; } = null!;
    }
}
