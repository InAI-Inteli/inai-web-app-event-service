using AutoMapper;
using WebAPIEventService.Domain.DTOs.Responses;
using WebAPIEventService.Domain.DTOs.ViewModels;
using WebAPIEventService.Domain.Entities;

namespace WebAPIEventService.Domain.DTOs.Helpers
{
    public class AnfitriaoProfile : Profile
    {
        public AnfitriaoProfile()
        {
            CreateMap<AnfitriaoAddViewModel, Anfitriao>();
            CreateMap<Anfitriao, AnfitriaoDto>();
        }
    }
}
