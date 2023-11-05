namespace WebAPIEventService.Domain.DTOs.ViewModels
{
    public class AnfitriaoUpdateViewModel
    {
        public int Id { get; set; }
        public int IdEvento { get; set; }
        public string? Nome { get; set; }
        public string? Imagem { get; set; }
        public string? Formacao { get; set; }
        public string? Descricao { get; set; }
        public string? RedeSocial { get; set; }
        public string? Profissao { get; set; }
    }
}
