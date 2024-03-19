





using CodeFirstApi.PartTwo.Data;
using CodeFirstApi.PartTwo.Data.Model;
using CodeFirstApi.PartTwo.Model;

namespace CodeFirstApi.PartTwo.Interface
{
    public interface ICarRepository
    {
        Task<Car> CreateAsync(Car car);
   
        Task<Car> GetAsync(int id);
        Task<int> UpdateAsync( Car car);
        Task DeleteAsync(int id);
        Task<List<Car>> GetAllAsync();

    }
}
