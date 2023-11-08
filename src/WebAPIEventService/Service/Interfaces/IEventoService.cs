using WebAPIEventService.Domain.Entities;

namespace WebAPIEventService.Service.Interfaces
{
    public interface IEventoService
    {
        public Task<Evento?> GetEventoByIdAsync(int id);
        public Task<IEnumerable<Evento>> GetAllEventosAsync();
        public Task UpdateEventoAsync(Evento evento);
        public Task AddEventoAsync(Evento evento);
        public Task DeleteEventoAsync(int id);
    }
}
