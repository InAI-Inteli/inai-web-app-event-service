using WebAPIEventService.Infra.Data.Context;
using WebAPIEventService.Infra.Data.Repository.Interfaces;

namespace WebAPIEventService.Infra.Data.Repository
{
    public class InscricaoRepository : BaseRepository, IInscricaoRepository
    {
        public InscricaoRepository(EventContext context) : base(context)
        {
        }
    }
}
