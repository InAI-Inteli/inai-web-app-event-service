namespace WebAPIEventService.Domain.DTOs.Responses
{
    public class EventoDto
    {
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
