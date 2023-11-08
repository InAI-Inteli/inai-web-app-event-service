using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIEventService.Domain.Entities;
using WebAPIEventService.Infra.Data.Repository.Interfaces;
using WebAPIEventService.Infra.Data.UnitOfWork;
using WebAPIEventService.Service.Interfaces;

namespace WebAPIEventService.Service.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IUnitOfWork _uow;

        public EventoService(IEventoRepository eventoRepository, IUnitOfWork uow)
        {
            _eventoRepository = eventoRepository;
            _uow = uow;
        }

        public async Task<Evento?> GetEventoByIdAsync(int id)
        {
            return await _eventoRepository.GetByIdAsync<Evento>(id);
        }

        public async Task<IEnumerable<Evento>> GetAllEventosAsync()
        {
            return await _eventoRepository.GetAllAsync<Evento>();
        }

        public async Task UpdateEventoAsync(Evento evento)
        {
            _eventoRepository.Update(evento);
            await _uow.Commit();
        }

        public async Task AddEventoAsync(Evento evento)
        {
            _eventoRepository.Add(evento);
            await _uow.Commit();
        }
        public async Task DeleteEventoAsync(int id)
        {
            var evento = await _eventoRepository.GetByIdAsync<Evento>(id) ?? throw new Exception("Evento not found");
            _eventoRepository.Delete(evento);
            await _uow.Commit();
        }
    }
}
