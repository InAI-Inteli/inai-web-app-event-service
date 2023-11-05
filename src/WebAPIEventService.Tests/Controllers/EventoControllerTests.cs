using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIEventService.Application.Controllers;
using WebAPIEventService.Domain.DTOs.Responses;
using WebAPIEventService.Domain.DTOs.ViewModels;
using WebAPIEventService.Domain.Entities;
using WebAPIEventService.Service.Interfaces;
using Xunit;

namespace WebAPIEventService.Tests.Controllers
{
    public class EventoControllerTests
    {
        private readonly EventoController _eventoController;
        private readonly IEventoService _eventoService;
        private readonly IMapper _mapper;

        public EventoControllerTests()
        {
            _eventoService = A.Fake<IEventoService>();
            _mapper = A.Fake<IMapper>();

            _eventoController = new EventoController(_eventoService, _mapper);
        }

        [Fact]
        public async Task GetEventoById_ReturnsOk()
        {
            // Arrange
            int eventoId = 1;
            var fakeEvento = CreateFakeEvento(eventoId, "Evento de Teste 1");
            var fakeEventoDto = A.Dummy<EventoDto>();

            A.CallTo(() => _eventoService.GetEventoByIdAsync(eventoId)).Returns(fakeEvento);
            A.CallTo(() => _mapper.Map<EventoDto>(fakeEvento)).Returns(fakeEventoDto);

            // Act
            var result = await _eventoController.GetEventoById(eventoId);

            // Assert
            result.Should().BeOfType<ActionResult<EventoDto>>();

            var actionResult = result.As<ActionResult<EventoDto>>();
            actionResult.Result.Should().BeOfType<OkObjectResult>();

            var okResult = actionResult.Result.As<OkObjectResult>();
            okResult.Value.Should().BeAssignableTo<EventoDto>();

            var model = okResult.Value.As<EventoDto>();
            model.Should().BeEquivalentTo(fakeEventoDto);
        }

        [Fact]
        public async Task GetEventoById_ReturnsNotFound()
        {
            // Arrange
            int eventoId = 2;

            A.CallTo(() => _eventoService.GetEventoByIdAsync(eventoId)).Returns((Evento?)null);

            // Act
            var result = await _eventoController.GetEventoById(eventoId);

            // Assert
            result.Should().BeOfType<ActionResult<EventoDto>>();

            var actionResult = result.As<ActionResult<EventoDto>>();
            actionResult.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task GetEventos_ReturnsOk()
        {
            // Arrange
            var fakeEventos = CreateFakeEventos(2);
            var fakeEventosDto = A.CollectionOfDummy<EventoDto>(fakeEventos.Count);

            A.CallTo(() => _eventoService.GetAllEventosAsync()).Returns(fakeEventos);
            A.CallTo(() => _mapper.Map<IEnumerable<EventoDto>>(A<IEnumerable<Evento>>.Ignored)).Returns(fakeEventosDto);

            // Act
            var result = await _eventoController.GetEventos();

            // Assert
            result.Should().BeOfType<ActionResult<IEnumerable<EventoDto>>>();

            var actionResult = result.As<ActionResult<IEnumerable<EventoDto>>>();
            actionResult.Result.Should().BeOfType<OkObjectResult>();

            var okResult = actionResult.Result.As<OkObjectResult>();
            okResult.Value.Should().BeAssignableTo<IEnumerable<EventoDto>>();

            var model = okResult.Value.As<IEnumerable<EventoDto>>();
            model.Should().HaveCount(fakeEventosDto.Count);
        }

        [Fact]
        public async Task CreateEvento_ReturnsCreated()
        {
            // Arrange
            var fakeEventoAddViewModel = A.Dummy<EventoAddViewModel>();
            var fakeEvento = A.Dummy<Evento>();

            A.CallTo(() => _mapper.Map<Evento>(fakeEventoAddViewModel)).Returns(fakeEvento);

            // Act
            var result = await _eventoController.CreateEvento(fakeEventoAddViewModel);

            // Assert
            result.Should().BeOfType<CreatedResult>();
        }

        [Fact]
        public async Task CreateEvento_ReturnsBadRequest_WhenModelIsInvalid()
        {
            // Arrange
            var fakeInvalidEventoAddViewModel = new EventoAddViewModel();
            _eventoController.ModelState.AddModelError("nome", "Nome em branco");

            // Act
            var result = await _eventoController.CreateEvento(fakeInvalidEventoAddViewModel);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task UpdateEvento_ReturnsOk()
        {
            // Arrange
            int eventoId = 1;
            var fakeEventoUpdateViewModel = new EventoUpdateViewModel
            {
                Id = eventoId,
                Nome = "Evento de Teste 1 Atualizado"
            };
            var fakeEvento = CreateFakeEvento(eventoId, "Evento de Teste 1 Atualizado");

            A.CallTo(() => _mapper.Map<Evento>(fakeEventoUpdateViewModel)).Returns(fakeEvento);
            A.CallTo(() => _eventoService.UpdateEventoAsync(fakeEvento)).Returns(Task.CompletedTask);

            // Act
            var result = await _eventoController.UpdateEvento(eventoId, fakeEventoUpdateViewModel);

            // Assert
            result.Should().BeOfType<OkResult>();
        }

        [Fact]
        public async Task UpdateEvento_ReturnsBadRequest_WhenModelIsInvalid()
        {
            // Arrange
            int eventoId = -555;
            var fakeEventoUpdateViewModel = new EventoUpdateViewModel
            {
                Id = eventoId,
                Nome = null
            };

            // Act
            var result = await _eventoController.UpdateEvento(eventoId, fakeEventoUpdateViewModel);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task UpdateEvento_ReturnsNotFound()
        {
            // Arrange
            int eventoId = 3;
            var fakeEventoUpdateViewModel = new EventoUpdateViewModel
            {
                Id = eventoId,
                Nome = "asdf"
            };

            A.CallTo(() => _mapper.Map<Evento>(fakeEventoUpdateViewModel)).Returns(A.Dummy<Evento>());
            A.CallTo(() => _eventoService.UpdateEventoAsync(A<Evento>.Ignored)).Throws<Exception>();

            // Act
            var result = await _eventoController.UpdateEvento(eventoId, fakeEventoUpdateViewModel);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task DeleteEvento_ReturnsOk()
        {
            // Arrange
            int eventoId = 1;

            A.CallTo(() => _eventoService.DeleteEventoAsync(eventoId)).Returns(Task.CompletedTask);

            // Act
            var result = await _eventoController.DeleteEvento(eventoId);

            // Assert
            result.Should().BeOfType<OkResult>();
        }

        [Fact]
        public async Task DeleteEvento_ReturnsBadRequest_WhenModelIsInvalid()
        {
            // Arrange
            int eventoId = 0;

            // Act
            var result = await _eventoController.DeleteEvento(eventoId);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task DeleteEvento_ReturnsNotFound()
        {
            // Arrange
            int eventoId = 2;

            A.CallTo(() => _eventoService.DeleteEventoAsync(eventoId)).Throws<Exception>();

            // Act
            var result = await _eventoController.DeleteEvento(eventoId);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        private static Evento CreateFakeEvento(int id, string nome)
        {
            return new Evento
            {
                Id = id,
                Nome = nome
            };
        }

        private static List<Evento> CreateFakeEventos(int count)
        {
            var eventos = new List<Evento>();
            for (int i = 1; i <= count; i++)
            {
                eventos.Add(CreateFakeEvento(i, $"Evento {i}"));
            }
            return eventos;
        }
    }
}
