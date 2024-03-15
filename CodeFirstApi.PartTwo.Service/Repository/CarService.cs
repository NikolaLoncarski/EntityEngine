using CodeFirstApi.PartTwo.Data;
using CodeFirstApi.PartTwo.Interface;
using CodeFirstApi.PartTwo.Model;
using CodeFirstApi.PartTwo.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstApi.PartTwo.Service.Repository
{
    public class CarService : ICarService
    {

        private readonly ICarRepository _carRepository;
        public CarService (ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<Car> CreateCarService(Car car)
        {
          return await _carRepository.CreateAsync(car);
        }

        public async Task<Car> DeleteCarService(int id)
        {
       return await _carRepository.DeleteAsync(id);
        }

        public async Task<Car> GetCarService(int id)
        {
           return await _carRepository.GetAsync(id);
        }

        public async Task UpdateCarService(Car car)
        {
            await _carRepository.UpdateAsync(car);
        }
    }
}
