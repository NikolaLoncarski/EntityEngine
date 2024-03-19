﻿using CodeFirstApi.PartTwo.Data;
using CodeFirstApi.PartTwo.Data.Model;
using CodeFirstApi.PartTwo.Model;
using CodeFirstApi.PartTwo.Service.ExternalAPI;
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
        public async Task<IActionResult> GetCar(int id)
        {
            var data = await _carService.GetCarService(id);
            return Ok(data);
        }

        [HttpDelete]
        [Route("DeleteCar")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carService.DeleteCarService(id);
            return NoContent();
        }
        [HttpPost]
        [Route("CreateCar")]
        public async Task<IActionResult> CreateCar(Car car)
        {
              

            Car newCar = await _carService.CreateCarService(car);
            return Ok(newCar);
        }

        [HttpPut]
        [Route("UpdateCar")]
        public async Task<IActionResult> UpdateCar([FromBody] Car car)
        {
           var updatedCar = await _carService.UpdateCarService(car);
            return Ok(updatedCar);
       
        }

       

        [HttpGet]
        [Route("GetAllCars")]
        public async Task<IActionResult> GetAllCars()
        {
            var allCars = await _carService.GetAllCarService();

            return Ok(allCars);

        }


    }
}
