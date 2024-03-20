
using CodeFirstApi.PartTwo.Data;
using CodeFirstApi.PartTwo.Data.Model;
using CodeFirstApi.PartTwo.Interface;

using CodeFirstApi.PartTwo.Service.Repository;

using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstApi.PartTwo.Tests.Repository
{
    public class CodeFirstApi
    {





        [Fact]
        public async Task CreateAsync_ValidRequest_ReturnsObject()
        {
            // Arrange
            Engine engine = new Engine()
            {
                Id = 1,

                Year = 2020,

                Brand = "audi",
                SerialNumber = 1234,
            };
            Engine engine1 = new Engine()
            {


                Year = 2020,

                Brand = "audi",
                SerialNumber = 1234,
            };
            var engines = new List<Engine>();

            var mockDbSet = new Mock<DbSet<Engine>>();
            mockDbSet.As<IQueryable<Engine>>().Setup(m => m.Provider).Returns(engines.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Engine>>().Setup(m => m.Expression).Returns(engines.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Engine>>().Setup(m => m.ElementType).Returns(engines.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Engine>>().Setup(m => m.GetEnumerator()).Returns(() => engines.GetEnumerator());
            mockDbSet.Setup(m => m.Add(It.IsAny<Engine>())).Callback<Engine>(m => engines.Add(m));

            var mockContext = new Mock<AppDbContext>();
            mockContext.Setup(c => c.Engines).Returns(mockDbSet.Object);

            var mockService = new Mock<IEngineRepository>();
            mockService.Setup(s => s.GetAllAsync());

            var repo = new EngineRepository(mockContext.Object);

            // Act
            var actionResult = await repo.GetAllAsync();




            Assert.NotNull(actionResult);





        }
    }
}
