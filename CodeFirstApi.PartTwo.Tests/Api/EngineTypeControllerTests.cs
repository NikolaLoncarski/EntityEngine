using CodeFirstApi.PartTwo.Controllers;
using CodeFirstApi.PartTwo.Data.Model;
using CodeFirstApi.PartTwo.Model;
using CodeFirstApi.PartTwo.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstApi.PartTwo.Tests.Api
{
    public class EngineTypeControllerTests
    {
        [Fact]
        public async void GetEngineType_ValidId_ReturnsObject()
        {
            // Arrange
            EngineType engineType = new EngineType()
            {
                Id = 1,

                Model = "Electric",
                Name = "X1123"
            };



            var mockRepository = new Mock<IEngineTypeService>();
            mockRepository.Setup(x => x.GetEngineTypeService(1)).ReturnsAsync(engineType);



            var controller = new EngineTypeController(mockRepository.Object);

            // Act
            var actionResult = await controller.GetAsync(1) as OkObjectResult;

            // Assert
            Assert.NotNull(actionResult);


            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);
            Assert.Equal(engineType, actionResult.Value);
        }

        [Fact]
        public async void GetEngineType_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var mockRepository = new Mock<IEngineTypeService>();

            var controller = new EngineTypeController(mockRepository.Object);

            // Act
            var actionResult = await controller.GetAsync(12213456) as NotFoundResult;

            // Assert
            Assert.Null(actionResult);
        }

        [Fact]
        public async void UpdateEngineType_ValidRequest_ReturnsValidId()
        {
            // Arrange
            EngineType engineType = new EngineType()
            {
                Id = 1,

                Model = "Electric",
                Name = "X1123"
            };

            var mockRepository = new Mock<IEngineTypeService>();
            mockRepository.Setup(x => x.UpdateEngineTypeService(engineType)).ReturnsAsync(1);

            var controller = new EngineTypeController(mockRepository.Object);

            // Act
            var actionResult = await controller.UpdateEngineType(engineType) as OkObjectResult;

            // Assert
            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);

            Assert.Equal(1, actionResult.Value);
        }

        [Fact]
        public async void DeleteEngineType_ValidId_ReturnsNoContent()
        {
            // Arrange
            EngineType engineType = new EngineType()
            {
                Id = 1,

                Model = "Electric",
                Name = "X1123"
            };

            var mockRepository = new Mock<IEngineTypeService>();
            mockRepository.Setup(x => x.DeleteEngineTypeService(1));

            var controller = new EngineTypeController(mockRepository.Object);

            // Act
            var actionResult = await controller.DeleteEngineType(1) as NoContentResult;

            // Assert
            Assert.NotNull(actionResult);
        }

        [Fact]
        public async void DeleteEngineType_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var mockRepository = new Mock<IEngineTypeService>();

            var controller = new EngineTypeController(mockRepository.Object);

            // Act
            var actionResult = await controller.DeleteEngineType(55456);

            // Assert
            Assert.NotNull(actionResult);
        }

        [Fact]
        public async void GetEngineTypes_ReturnsCollection()
        {
            // Arrange
            List<EngineType> engineTypes = new List<EngineType>() {
                new EngineType()  {
           Id = 1,

                Model = "Electric",
                Name = "X1123"
                },
                new EngineType()  {
     Id = 1,

                Model = "Electric",
                Name = "X1123"
                }
            };

            var mockRepository = new Mock<IEngineTypeService>();
            mockRepository.Setup(x => x.GetAllEngineTypesService()).ReturnsAsync(engineTypes);

            var controller = new EngineTypeController(mockRepository.Object);

            // Act
            var actionResult = await controller.GetAllEngineTypes() as OkObjectResult;

            // Assert
            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);

            List<EngineType> listResult = (List<EngineType>)actionResult.Value;

            for (int i = 0; i < listResult.Count; i++)
            {
                Assert.Equal(engineTypes[i], listResult[i]);
            }
        }
        [Fact]
        public async void PostEngineType_ValidRequest_ReturnsObject()
        {
            // Arrange
            EngineType engineType = new EngineType()
            {
                Id = 1,

                Model = "Electric",
                Name = "X1123"
            };

            var mockRepository = new Mock<IEngineTypeService>();
            mockRepository.Setup(x => x.CreateEngineTypeService(engineType)).ReturnsAsync(engineType);

            var controller = new EngineTypeController(mockRepository.Object);

            // Act
            var actionResult = await controller.CreateEngineType(engineType) as OkObjectResult;

            // Assert
            Assert.NotNull(actionResult);



            Assert.NotNull(actionResult.Value);
            Assert.Equal(engineType, actionResult.Value);
        }
    }
}
