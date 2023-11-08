using WebAPIEventService.Infra.Data.Context;
using WebAPIEventService.Infra.Data.Repository.Interfaces;

namespace WebAPIEventService.Infra.Data.Repository
{
    public class EventoRepository : BaseRepository, IEventoRepository
    {
        public EventoRepository(EventContext context) : base(context)
        {
        }
    }
}
