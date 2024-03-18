using CodeFirstApi.PartTwo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstApi.PartTwo.Service.Interface
{
 public interface ICarService
    {
        Task<Car> CreateCarService(Car car);

        Task<Car> GetCarService(int id);
        Task<int> UpdateCarService(Car car);
        Task DeleteCarService(int id);
        Task<List<Car>> GetAllCarService();


    }
}
