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

        /// </returns>
        [HttpGet]
        [Route("GetCar")]
        public async Task<ActionResult<IEnumerable<Car>>> GetAsync(int id)
        {
            var data = await _carService.GetCarService(id);
            return Ok(data);
        }


    }
}
