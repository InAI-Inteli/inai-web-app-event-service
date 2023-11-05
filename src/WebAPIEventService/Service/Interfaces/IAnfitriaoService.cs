using WebAPIEventService.Domain.Entities;

namespace WebAPIEventService.Service.Interfaces
{
    public interface IAnfitriaoService
    {
        public Task AddAnfitriaoAsync(Anfitriao anfitriao);
    }
}
