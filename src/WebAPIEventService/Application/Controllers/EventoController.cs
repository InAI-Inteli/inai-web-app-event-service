using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPIEventService.Domain.DTOs.Responses;
using WebAPIEventService.Domain.DTOs.ViewModels;
using WebAPIEventService.Domain.Entities;
using WebAPIEventService.Service.Interfaces;

namespace WebAPIEventService.Application.Controllers
{
    [Route("eventos")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;
        private readonly IMapper _mapper;

        public EventoController(IEventoService eventoService, IMapper mapper)
        {
            _eventoService = eventoService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventoDto>> GetEventoById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID de evento inválido");
            }

            Evento? evento = await _eventoService.GetEventoByIdAsync(id);

            if (evento == null)
            {
                return NotFound();
            }

            EventoDto eventoResponse = _mapper.Map<EventoDto>(evento);

            return Ok(eventoResponse);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoDto>>> GetEventos()
        {
            IEnumerable<Evento> eventos = await _eventoService.GetAllEventosAsync();

            IEnumerable<EventoDto> eventosResponse = _mapper.Map<IEnumerable<EventoDto>>(eventos);

            return Ok(eventosResponse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvento(EventoAddViewModel evento)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(errors);
            }

            Evento eventoEntity = _mapper.Map<Evento>(evento);

            await _eventoService.AddEventoAsync(eventoEntity);

            string resourceUrl = $"/eventos/{eventoEntity.Id}";

            return Created(resourceUrl, null);
        }

        [HttpPut("editar/{id:int}")]
        public async Task<IActionResult> UpdateEvento(int id, EventoUpdateViewModel evento)
        {
            if (id <= 0 || id != evento.Id)
            {
                return BadRequest("ID de evento inválido ou incompatível.");
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(errors);
            }

            try
            {
                Evento eventoEntity = _mapper.Map<Evento>(evento);
                await _eventoService.UpdateEventoAsync(eventoEntity);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID de evento inválido");
            }

            try
            {
                await _eventoService.DeleteEventoAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
