using AutoMapper;
using WebAPIEventService.Domain.DTOs.Responses;
using WebAPIEventService.Domain.DTOs.ViewModels;
using WebAPIEventService.Domain.Entities;

namespace WebAPIEventService.Domain.DTOs.Helpers
{
    public class EventoProfile : Profile
    {
        public EventoProfile() 
        {
            CreateMap<EventoAddViewModel, Evento>();
            CreateMap<Evento, EventoDto>();
        }
    }
}
