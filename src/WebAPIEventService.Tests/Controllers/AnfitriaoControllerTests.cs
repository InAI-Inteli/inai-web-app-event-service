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
    public class AnfitriaoControllerTests
    {
        private readonly AnfitriaoController _anfitriaoController;
        private readonly IAnfitriaoService _anfitriaoService;
        private readonly IMapper _mapper;

        public AnfitriaoControllerTests()
        {
            _anfitriaoService = A.Fake<IAnfitriaoService>();
            _mapper = A.Fake<IMapper>();

            _anfitriaoController = new AnfitriaoController(_anfitriaoService, _mapper);
        }

        [Fact]
        public async Task CreateAnfitriao_ReturnsCreated()
        {
            // Arrange
            var fakeAnfitriaoAddViewModel = A.Dummy<AnfitriaoAddViewModel>();
            var fakeAnfitriao = A.Dummy<Anfitriao>();

            A.CallTo(() => _mapper.Map<Anfitriao>(fakeAnfitriaoAddViewModel)).Returns(fakeAnfitriao);

            // Act
            var result = await _anfitriaoController.CreateAnfitriao(fakeAnfitriaoAddViewModel);

            // Assert
            result.Should().BeOfType<CreatedResult>();
        }

        [Fact]
        public async Task CreateAnfitriao_ReturnsBadRequest_WhenModelIsInvalid()
        {
            // Arrange
            var fakeInvalidAnfitriaoAddViewModel = new AnfitriaoAddViewModel();
            _anfitriaoController.ModelState.AddModelError("Nome", "Nome em branco");

            // Act
            var result = await _anfitriaoController.CreateAnfitriao(fakeInvalidAnfitriaoAddViewModel);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        private static Anfitriao CreateFakeAnfitriao(int id, string nome)
        {
            return new Anfitriao
            {
                Id = id,
                Nome = nome
            };
        }
    }
}
