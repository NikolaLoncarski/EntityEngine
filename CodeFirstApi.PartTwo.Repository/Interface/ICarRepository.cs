





using CodeFirstApi.PartTwo.Model;

namespace CodeFirstApi.PartTwo.Interface
{
    public interface ICarRepository
    {
        Task<Car> CreateAsync(Car car);
   
        Task<Car> GetAsync(int id);
        Task UpdateAsync( Car car);
        Task<Car> DeleteAsync(int id);

    }
}
