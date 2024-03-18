using CodeFirstApi.PartTwo.Model;

namespace CodeFirstApi.PartTwo.Interface
{
    public interface IEngineRepository
    {
        Task<int> CreateAsync(Engine engine);

        Task<Engine> GetAsync(int id);
        Task<int> UpdateAsync( Engine engine);
        Task DeleteAsync(int id);

        Task <List<Engine>> GetAllAsync();

    }
}
