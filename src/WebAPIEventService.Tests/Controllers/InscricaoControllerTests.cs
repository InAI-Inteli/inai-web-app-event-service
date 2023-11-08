using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIEventService.Application.Controllers;
using WebAPIEventService.Domain.DTOs.ViewModels;
using WebAPIEventService.Domain.Entities;
using WebAPIEventService.Service.Interfaces;
using Xunit;

namespace WebAPIEventService.Tests.Controllers
{
    public class InscricaoControllerTests
    {
        private readonly InscricaoController _inscricaoController;
        private readonly IInscricaoService _inscricaoService;
        private readonly IMapper _mapper;

        public InscricaoControllerTests()
        {
            _inscricaoService = A.Fake<IInscricaoService>();
            _mapper = A.Fake<IMapper>();

            _inscricaoController = new InscricaoController(_inscricaoService, _mapper);
        }

        [Fact]
        public async Task CreateInscricao_ReturnsCreated()
        {
            // Arrange
            var fakeInscricaoAddViewModel = A.Dummy<InscricaoAddViewModel>();
            var fakeInscricao = A.Dummy<Inscricao>();

            A.CallTo(() => _mapper.Map<Inscricao>(fakeInscricaoAddViewModel)).Returns(fakeInscricao);

            // Act
            var result = await _inscricaoController.CreateInscricao(fakeInscricaoAddViewModel);

            // Assert
            result.Should().BeOfType<CreatedResult>();
        }

        [Fact]
        public async Task CreateInscricao_ReturnsBadRequest_WhenModelIsInvalid()
        {
            // Arrange
            var fakeInvalidInscricaoAddViewModel = new InscricaoAddViewModel();
            _inscricaoController.ModelState.AddModelError("Nome", "Nome em branco");

            // Act
            var result = await _inscricaoController.CreateInscricao(fakeInvalidInscricaoAddViewModel);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        private static Inscricao CreateFakeInscricao(int id, string nome)
        {
            return new Inscricao
            {
                Id = id,
                Nome = nome
            };
        }
    }
}
