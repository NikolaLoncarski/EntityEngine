using AutoMapper;
using CodeFirstApi.PartTwo.Data;

using CodeFirstApi.PartTwo.Data.Model;
using CodeFirstApi.PartTwo.Interface;
using CodeFirstApi.PartTwo.Model;
using CodeFirstApi.PartTwo.Service.Dto;
using CodeFirstApi.PartTwo.Service.ExternalAPI;
using CodeFirstApi.PartTwo.Service.Interface;
using CodeFirstApi.PartTwo.Service.ValidationModel;
using FluentValidation;
using FluentValidation.Results;
using System;


namespace CodeFirstApi.PartTwo.Service.Repository
{
    public class CarService : ICarService
    {

        private readonly ICarRepository _carRepository;
        private IValidator<Car> _validator;
        private readonly IMapper _mapper;
        public CarService (ICarRepository carRepository, IValidator<Car> validator,IMapper mapper)
        {
            _carRepository = carRepository;
            _validator = validator;
            _mapper = mapper;


     
    }
        public async Task<Car> CreateCarService(CarRequestDTO carRequestDTO)
        {
            var car = _mapper.Map<Car>(carRequestDTO);

            var result = await _validator.ValidateAsync(car);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors[0].ErrorMessage);
              
            }



            return await _carRepository.CreateAsync(car);
        }

        public async Task DeleteCarService(int id)
        {
      await _carRepository.DeleteAsync(id);
           }

        public async Task<List<Car>> GetAllCarService()
        {


            return await _carRepository.GetAllAsync();
        }

        public async Task<Car> GetCarService(int id)
        {
           return await _carRepository.GetAsync(id);
        }

        public async Task<int> UpdateCarService(Car car)
        {
          var updatedCar =  await _carRepository.UpdateAsync(car);

            return updatedCar;
        }
    }
}
