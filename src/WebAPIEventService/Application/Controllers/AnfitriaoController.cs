using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPIEventService.Domain.DTOs.Responses;
using WebAPIEventService.Domain.DTOs.ViewModels;
using WebAPIEventService.Domain.Entities;
using WebAPIEventService.Service.Interfaces;

namespace WebAPIEventService.Application.Controllers
{
    [Route("anfitriao")]
    [ApiController]
    public class AnfitriaoController : ControllerBase
    {
        private readonly IAnfitriaoService _anfitriaoService;
        private readonly IMapper _mapper;

        public AnfitriaoController(IAnfitriaoService anfitriaoService, IMapper mapper)
        {
            _anfitriaoService = anfitriaoService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnfitriao(AnfitriaoAddViewModel anfitriao)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(errors);
            }

            Anfitriao anfitriaoEntity = _mapper.Map<Anfitriao>(anfitriao);

            await _anfitriaoService.AddAnfitriaoAsync(anfitriaoEntity);

            string resourceUrl = $"/anfitriao/{anfitriaoEntity.Id}";

            return Created(resourceUrl, null);
        }
    }
}
