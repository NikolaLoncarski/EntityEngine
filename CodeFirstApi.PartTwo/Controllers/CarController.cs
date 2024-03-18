using CodeFirstApi.PartTwo.Model;
using CodeFirstApi.PartTwo.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstApi.PartTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {


        private readonly ICarService _carService;

        public CarController (ICarService carService)
        {
            _carService = carService;
        }

 
        [HttpGet]
        [Route("GetCar")]
        public async Task<ActionResult<IEnumerable<Car>>> GetAsync(int id)
        {
            var data = await _carService.GetCarService(id);
            return Ok(data);
        }

        [HttpDelete]
        [Route("DeleteCar")]
        public async Task<ActionResult<IEnumerable<Car>>> DeleteCar(int id)
        {
            await _carService.DeleteCarService(id);
            return NoContent();
        }
        [HttpPost]
        [Route("CreateCar")]
        public async Task<ActionResult<IEnumerable<Car>>> CreateCar(Car car)
        {
            var data = await _carService.CreateCarService(car);
            return Ok(data);
        }

        [HttpPut]
        [Route("UpdateCar")]
        public async Task<ActionResult<IEnumerable<Car>>> UpdateCar([FromBody] Car car)
        {
           var updatedCar = await _carService.UpdateCarService(car);
            return Ok(updatedCar);
       
        }

        [HttpGet]
        [Route("GetAllCars")]
        public async Task<ActionResult<IEnumerable<Car>>> GetAllCars()
        {
            var allCars = await _carService.GetAllCarService();
            return Ok(allCars);

        }


    }
}
