using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPIEventService.Domain.DTOs.Responses;
using WebAPIEventService.Domain.DTOs.ViewModels;
using WebAPIEventService.Domain.Entities;
using WebAPIEventService.Service.Interfaces;

namespace WebAPIEventService.Application.Controllers
{
    [Route("inscricao")]
    [ApiController]
    public class InscricaoController : ControllerBase
    {
        private readonly IInscricaoService _inscricaoService;
        private readonly IMapper _mapper;

        public InscricaoController(IInscricaoService inscricaoService, IMapper mapper)
        {
            _inscricaoService = inscricaoService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateInscricao(InscricaoAddViewModel inscricao)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(errors);
            }

            Inscricao inscricaoEntity = _mapper.Map<Inscricao>(inscricao);

            await _inscricaoService.AddInscricaoAsync(inscricaoEntity);

            string resourceUrl = $"/inscricao/{inscricaoEntity.Id}";

            return Created(resourceUrl, null);
        }
    }
}
