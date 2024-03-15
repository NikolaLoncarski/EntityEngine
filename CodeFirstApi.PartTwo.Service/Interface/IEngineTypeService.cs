using CodeFirstApi.PartTwo.Model;

namespace CodeFirstApi.PartTwo.Service.Interface
{
    public interface IEngineTypeService
    {
        Task<EngineType> CreateEngineTypeService(EngineType engineType);

        Task<EngineType> GetEngineTypeService(int id);
        Task UpdateEngineTypeService( EngineType engineType);
        Task<EngineType> DeleteEngineTypeService(int id);
    }
}
