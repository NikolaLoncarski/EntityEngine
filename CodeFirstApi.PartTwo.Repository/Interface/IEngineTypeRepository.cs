using CodeFirstApi.PartTwo.Model;

namespace CodeFirstApi.PartTwo.Repository.Interface
{
    public interface IEngineTypeRepository
    {
        Task<EngineType> CreateAsync(EngineType engineType);

        Task<EngineType> GetAsync(int id);
        Task UpdateAsync( EngineType engineType);
        Task<EngineType> DeleteAsync(int id);
    }
}
