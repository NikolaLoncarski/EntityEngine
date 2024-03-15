using CodeFirstApi.PartTwo.Model;

namespace CodeFirstApi.PartTwo.Interface
{
    public interface IEngineRepository
    {
        Task<Engine> CreateAsync(Engine engine);

        Task<Engine> GetAsync(int id);
        Task UpdateAsync( Engine engine);
        Task<Engine> DeleteAsync(int id);

    }
}
