using CodeFirstApi.PartTwo.Data.Model;
using CodeFirstApi.PartTwo.Model;

namespace CodeFirstApi.PartTwo.Interface
{
    public interface IEngineRepository
    {
        Task<Engine> CreateAsync(Engine engine);

        Task<Engine> GetAsync(int id);
        Task<int> UpdateAsync( Engine engine);
        Task DeleteAsync(int id);

        Task <List<Engine>> GetAllAsync();

    }
}
