
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit.Sdk;
using CodeFirstApi.PartTwo.Data.Model;
using CodeFirstApi.PartTwo.Controllers;
using CodeFirstApi.PartTwo.Service.Interface;
using AutoMapper;

using CodeFirstApi.PartTwo.Service.Dto;


namespace CodeFirstApi.PartTwo.Tests.Api
{
    public class CarControllerTests
    {

        [Fact]
        public async void GetCar_ValidId_ReturnsObject()
        {
            // Arrange
            Car car = new Car()
            {
                Id = 1,
                Color = "Red",
                Year = 2020,
                ChasisNumber = 11234,
                Brand = "audi",
                Model = "Q8",
            };



            var mockRepository = new Mock<ICarService>();
            mockRepository.Setup(x => x.GetCarService(1)).ReturnsAsync(car);


            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new CarProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new CarController(mockRepository.Object, mapper);

            // Act
            var actionResult = await controller.GetCar(1) as OkObjectResult;

            // Assert
            Assert.NotNull(actionResult);


            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);
            Assert.Equal(car, actionResult.Value);
        }

        [Fact]
        public async void GetCar_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var mockRepository = new Mock<ICarService>();

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new CarProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);


            var controller = new CarController(mockRepository.Object , mapper);

            // Act
            var actionResult = await controller.GetCar(12213456) as NotFoundResult;

            // Assert
            Assert.Null(actionResult);
        }

        [Fact]
        public async void UpdateCar_ValidRequest_ReturnsValidId()
        {
            // Arrange
            Car car = new Car()
            {
                Id = 1,
                Color = "Red",
                Year = 2020,
                ChasisNumber = 11234,
                Brand = "audi",
                Model = "Q8",
            };

            var mockRepository = new Mock<ICarService>();
            mockRepository.Setup(x => x.UpdateCarService(car)).ReturnsAsync(1);


            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new CarProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new CarController(mockRepository.Object, mapper);

            // Act
            var actionResult = await controller.UpdateCar(car) as OkObjectResult;

            // Assert
            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);

            Assert.Equal(1, actionResult.Value);
        }

        [Fact]
        public async void DeleteCar_ValidId_ReturnsNoContent()
        {
            // Arrange
            Car car = new Car()
            {
                Id = 1,
                Color = "Red",
                Year = 2020,
                ChasisNumber = 11234,
                Brand = "audi",
                Model = "Q8",
            };

            var mockRepository = new Mock<ICarService>();
            mockRepository.Setup(x => x.DeleteCarService(1));

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new CarProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);


            var controller = new CarController(mockRepository.Object, mapper);

            // Act
            var actionResult = await controller.DeleteCar(1) as NoContentResult;

            // Assert
            Assert.NotNull(actionResult);
        }

        [Fact]
        public async void DeleteCar_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var mockRepository = new Mock<ICarService>();

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new CarProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);


            var controller = new CarController(mockRepository.Object, mapper);

            // Act
            var actionResult = await controller.DeleteCar(55456);

            // Assert
            Assert.NotNull(actionResult);
        }

        [Fact]
        public async void GetCars_ReturnsCollection()
        {
            // Arrange
            List<Car> cars = new List<Car>() {
                new Car()  {
                    Id = 1,
                Color = "Red",
                Year = 2020,
                ChasisNumber = 11234,
                Brand = "audi",
                Model = "Q8",
                },
                new Car()  {
                       Id = 2,
                Color = "Red",
                Year = 2020,
                ChasisNumber = 11234,
                Brand = "audi",
                Model = "Q8",
                }
            };

            var mockRepository = new Mock<ICarService>();
            mockRepository.Setup(x => x.GetAllCarService()).ReturnsAsync(cars);

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new CarProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);


            var controller = new CarController(mockRepository.Object, mapper);

            // Act
            var actionResult = await controller.GetAllCars() as OkObjectResult;

            // Assert
            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);

            List<Car> listResult = (List<Car>)actionResult.Value;

            for (int i = 0; i < listResult.Count; i++)
            {
                Assert.Equal(cars[i], listResult[i]);
            }
        }
        [Fact]
        public async void PostCar_ValidRequest_ReturnsObject()
        {
            // Arrange

            CarRequestDTO carDto = new CarRequestDTO()
            {
            
                Color = "Red",
                Year = 2020,
                ChasisNumber = 11234,
                Brand = "audi",
                Model = "Q8",
            };






            Car car = new Car()
            {
                Color = "Red",
                Year = 2020,
                ChasisNumber = 11234,
                Brand = "audi",
                Model = "Q8",
            };

            var mockRepository = new Mock<ICarService>();
            mockRepository.Setup(x => x.CreateCarService(carDto)).ReturnsAsync(car);

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new CarProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);


            var controller = new CarController(mockRepository.Object, mapper);

            // Act
            var actionResult = await controller.CreateCar(carDto) as OkObjectResult;

            // Assert
            Assert.NotNull(actionResult);



            Assert.NotNull(actionResult.Value);
   

       
   
            Assert.Equal(car.Color, carDto.Color);
            Assert.Equal(car.Year, carDto.Year);
            Assert.Equal(car.ChasisNumber, carDto.ChasisNumber);
            Assert.Equal(car.Brand, carDto.Brand);
            Assert.Equal(car.Model, carDto.Model);
          


        }
    }
}
