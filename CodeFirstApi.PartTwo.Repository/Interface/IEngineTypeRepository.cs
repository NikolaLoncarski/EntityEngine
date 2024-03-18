using CodeFirstApi.PartTwo.Model;

namespace CodeFirstApi.PartTwo.Repository.Interface
{
    public interface IEngineTypeRepository
    {
        Task<EngineType> CreateAsync(EngineType engineType);

        Task<EngineType> GetAsync(int id);
        Task<int> UpdateAsync( EngineType engineType);
        Task DeleteAsync(int id);
        Task<List<EngineType>> GetAllAsync();
    }
}
