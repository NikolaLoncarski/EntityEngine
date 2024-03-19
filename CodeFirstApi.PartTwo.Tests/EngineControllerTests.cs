using CodeFirstApi.PartTwo.Controllers;
using CodeFirstApi.PartTwo.Data.Model;
using CodeFirstApi.PartTwo.Service;
using CodeFirstApi.PartTwo.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstApi.PartTwo.Tests
{
    public class EngineControllerTests
    {
        [Fact]
        public async void GetEngine_ValidId_ReturnsObject()
        {
            // Arrange
            Engine engine = new Engine()
            {
                Id = 1,

                Year = 2020,

                Brand = "audi",
                SerialNumber = 1234,
            };



            var mockRepository = new Mock<IEngineService>();
            mockRepository.Setup(x => x.GetEngineService(1)).ReturnsAsync(engine);



            var controller = new EngineController(mockRepository.Object);

            // Act
            var actionResult = await controller.GetAsync(1) as OkObjectResult;

            // Assert
            Assert.NotNull(actionResult);


            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);
            Assert.Equal(engine, actionResult.Value);
        }

        [Fact]
        public async void GetEngine_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var mockRepository = new Mock<IEngineService>();

            var controller = new EngineController(mockRepository.Object);

            // Act
            var actionResult = await controller.GetAsync(12213456) as NotFoundResult;

            // Assert
            Assert.Null(actionResult);
        }

        [Fact]
        public async void UpdateEngine_ValidRequest_ReturnsValidId()
        {
            // Arrange
            Engine engine = new Engine()
            {
                Id = 1,

                Year = 2020,

                Brand = "audi",
                SerialNumber = 1234,
            };

            var mockRepository = new Mock<IEngineService>();
            mockRepository.Setup(x => x.UpdateEngineService(engine)).ReturnsAsync(1);

            var controller = new EngineController(mockRepository.Object);

            // Act
            var actionResult = await controller.UpdateEngine(engine) as OkObjectResult;

            // Assert
            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);

            Assert.Equal(1, actionResult.Value);
        }

        [Fact]
        public async void DeleteEngine_ValidId_ReturnsNoContent()
        {
            // Arrange
            Engine engine = new Engine()
            {
                Id = 1,

                Year = 2020,

                Brand = "audi",
                SerialNumber = 1234,
            };

            var mockRepository = new Mock<IEngineService>();
            mockRepository.Setup(x => x.DeleteEngineService(1));

            var controller = new EngineController(mockRepository.Object);

            // Act
            var actionResult = await controller.DeleteEngine(1) as NoContentResult;

            // Assert
            Assert.NotNull(actionResult);
        }

        [Fact]
        public async void DeleteEngine_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var mockRepository = new Mock<IEngineService>();

            var controller = new EngineController(mockRepository.Object);

            // Act
            var actionResult = await controller.DeleteEngine(55456);

            // Assert
            Assert.NotNull(actionResult);
        }

        [Fact]
        public async void GetEngines_ReturnsCollection()
        {
            // Arrange
            List<Engine> engines = new List<Engine>() {
                new Engine()  {
         Id = 1,

                Year = 2020,

                Brand = "audi",
                SerialNumber = 1234,
                },
                new Engine()  {
        Id = 2,

                Year = 2020,

                Brand = "audi",
                SerialNumber = 1234,
                }
            };

            var mockRepository = new Mock<IEngineService>();
            mockRepository.Setup(x => x.GetAllEngineService()).ReturnsAsync(engines);

            var controller = new EngineController(mockRepository.Object);

            // Act
            var actionResult = await controller.GetAllEngines() as OkObjectResult;

            // Assert
            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);

            List<Engine> listResult = (List<Engine>)actionResult.Value;

            for (int i = 0; i < listResult.Count; i++)
            {
                Assert.Equal(engines[i], listResult[i]);
            }
        }
        [Fact]
        public async void PostEngine_ValidRequest_ReturnsObject()
        {
            // Arrange
            Engine engine = new Engine()
            {
                Id = 1,

                Year = 2020,

                Brand = "audi",
                SerialNumber = 1234,
            };

            var mockRepository = new Mock<IEngineService>();
            mockRepository.Setup(x => x.CreateEngineService(engine)).ReturnsAsync(engine);

            var controller = new EngineController(mockRepository.Object);

            // Act
            var actionResult = await controller.CreateEngine(engine) as OkObjectResult;

            // Assert
            Assert.NotNull(actionResult);



            Assert.NotNull(actionResult.Value);
            Assert.Equal(engine, actionResult.Value);
        }
    }
}

