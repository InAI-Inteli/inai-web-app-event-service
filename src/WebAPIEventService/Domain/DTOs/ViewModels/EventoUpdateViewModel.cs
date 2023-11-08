using System.ComponentModel.DataAnnotations;

namespace WebAPIEventService.Domain.DTOs.ViewModels
{
    public class EventoUpdateViewModel
    {
        [Required(ErrorMessage = "O campo 'Id' e obrigatorio.")]
        public int Id { get; set; }
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
    }
}
