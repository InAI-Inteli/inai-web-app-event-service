using WebAPIEventService.Domain.Entities;
using WebAPIEventService.Infra.Data.Repository.Interfaces;
using WebAPIEventService.Infra.Data.UnitOfWork;
using WebAPIEventService.Service.Interfaces;

namespace WebAPIEventService.Service.Services
{
    public class InscricaoService : IInscricaoService
    {
        private readonly IInscricaoRepository _inscricaoRepository;
        private readonly IUnitOfWork _uow;

        public InscricaoService(IInscricaoRepository inscricaoRepository, IUnitOfWork uow)
        {
            _inscricaoRepository = inscricaoRepository;
            _uow = uow;
        }

        public async Task AddInscricaoAsync(Inscricao inscricao)
        {
            _inscricaoRepository.Add(inscricao);
            await _uow.Commit();
        }
    }
}
