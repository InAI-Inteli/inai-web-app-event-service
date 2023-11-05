namespace WebAPIEventService.Domain.DTOs.ViewModels
{
    public class InscricaoAddViewModel
    {
        public int IdEvento { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? InstituicaoEnsino { get; set; }
        public string? Curso { get; set; }
        public string? Profissao { get; set; }
    }
}
