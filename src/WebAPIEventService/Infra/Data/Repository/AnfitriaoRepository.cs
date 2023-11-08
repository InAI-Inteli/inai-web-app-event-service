using WebAPIEventService.Infra.Data.Context;
using WebAPIEventService.Infra.Data.Repository.Interfaces;

namespace WebAPIEventService.Infra.Data.Repository
{
    public class AnfitriaoRepository : BaseRepository, IAnfitriaoRepository
    {
        public AnfitriaoRepository(EventContext context) : base(context)
        {
        }
    }
}
