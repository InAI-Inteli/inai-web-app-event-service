using WebAPIEventService.Domain.Entities;

namespace WebAPIEventService.Service.Interfaces
{
    public interface IInscricaoService
    {
        public Task AddInscricaoAsync(Inscricao inscricao);
    }
}
