using WebAPIEventService.Domain.Entities;
using WebAPIEventService.Infra.Data.Repository.Interfaces;
using WebAPIEventService.Infra.Data.UnitOfWork;
using WebAPIEventService.Service.Interfaces;

namespace WebAPIEventService.Service.Services
{
    public class AnfitriaoService : IAnfitriaoService
    {
        private readonly IAnfitriaoRepository _anfitriaoRepository;
        private readonly IUnitOfWork _uow;

        public AnfitriaoService(IAnfitriaoRepository anfitriaoRepository, IUnitOfWork uow)
        {
            _anfitriaoRepository = anfitriaoRepository;
            _uow = uow;
        }

        public async Task AddAnfitriaoAsync(Anfitriao anfitriao)
        {
            _anfitriaoRepository.Add(anfitriao);
            await _uow.Commit();
        }
    }
}
