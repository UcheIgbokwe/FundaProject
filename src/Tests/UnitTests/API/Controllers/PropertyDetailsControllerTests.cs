using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using src.API.Controllers;
using src.Domain.Entities;
using src.Domain.Interface;
using src.Domain.Request;
using Xunit;

namespace src.Tests.UnitTests.API.Controllers
{
    public class PropertyDetailsControllerTests
    {
        private readonly Mock<IHttpServices> _httpService;
        public PropertyDetailsControllerTests()
        {
            _httpService = new Mock<IHttpServices>();
        }

        [Fact]
        public async Task GetAgentsRankedByMostPropertiesAndGarden_Should_Not_Return_Null()
        {
            _httpService.Setup(repo => repo.GetAgentsRankedByMostPropertiesAndGarden())
                            .ReturnsAsync(new List<TopAgentsModel>());
            var controller = new PropertyDetailsController(_httpService.Object);

            var result = await controller.GetAgentsRankedByMostPropertiesAndGarden();

            var resultIsNotNull = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(new List<TopAgentsModel>(), resultIsNotNull.Value);
        }

        [Fact]
        public async Task GetAgentsRankedByMostPropertiesAndGarden_Should_Return_200()
        {
            _httpService.Setup(repo => repo.GetAgentsRankedByMostPropertiesAndGarden())
                            .ReturnsAsync(new List<TopAgentsModel>());
            var controller = new PropertyDetailsController(_httpService.Object);

            var result = await controller.GetAgentsRankedByMostPropertiesAndGarden();

            var resultIsNotNull = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, resultIsNotNull.StatusCode);
        }

        [Fact]
        public async Task GetAgentsRankedByMostProperties_Should_Not_Return_Null()
        {
            _httpService.Setup(repo => repo.GetAgentsRankedByMostProperties())
                            .ReturnsAsync(new List<TopAgentsModel>());
            var controller = new PropertyDetailsController(_httpService.Object);

            var result = await controller.GetAgentsRankedByMostProperties();

            var resultIsNotNull = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(new List<TopAgentsModel>(), resultIsNotNull.Value);
        }

        [Fact]
        public async Task GetAgentsRankedByMostProperties_Should_Return_200()
        {
            _httpService.Setup(repo => repo.GetAgentsRankedByMostProperties())
                            .ReturnsAsync(new List<TopAgentsModel>());
            var controller = new PropertyDetailsController(_httpService.Object);

            var result = await controller.GetAgentsRankedByMostProperties();

            var resultIsNotNull = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, resultIsNotNull.StatusCode);
        }

        [Fact]
        public async Task GetAllPropertyData_Should_Not_Return_Null()
        {
            RequestParams request = new()
            {
                Type = "koop",
                Zo = "/amsterdam"
            };
            _httpService.Setup(repo => repo.GetAllPropertyData(request.Type, request.Zo))
                            .ReturnsAsync(new List<PropertyDataModel>());
            var controller = new PropertyDetailsController(_httpService.Object);

            var result = await controller.GetAllPropertyData(request);

            var resultIsNotNull = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(new List<PropertyDataModel>(), resultIsNotNull.Value);
        }

        [Fact]
        public async Task GetAllPropertyData_Should_Return_200()
        {
            RequestParams request = new()
            {
                Type = "koop",
                Zo = "/amsterdam"
            };
            _httpService.Setup(repo => repo.GetAllPropertyData(request.Type, request.Zo))
                            .ReturnsAsync(new List<PropertyDataModel>());
            var controller = new PropertyDetailsController(_httpService.Object);

            var result = await controller.GetAllPropertyData(request);

            var resultIsNotNull = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, resultIsNotNull.StatusCode);
        }
    }
}