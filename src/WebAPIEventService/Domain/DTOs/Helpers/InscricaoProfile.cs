using AutoMapper;
using WebAPIEventService.Domain.DTOs.Responses;
using WebAPIEventService.Domain.DTOs.ViewModels;
using WebAPIEventService.Domain.Entities;

namespace WebAPIEventService.Domain.DTOs.Helpers
{
    public class InscricaoProfile : Profile
    {
        public InscricaoProfile()
        {
            CreateMap<InscricaoAddViewModel, Inscricao>();
            CreateMap<Inscricao, InscricaoDto>();
        }
    }
}
