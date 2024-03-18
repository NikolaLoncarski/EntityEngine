using CodeFirstApi.PartTwo.Model;

namespace CodeFirstApi.PartTwo.Service.Interface
{
    public interface IEngineTypeService
    {
        Task<EngineType> CreateEngineTypeService(EngineType engineType);

        Task<EngineType> GetEngineTypeService(int id);
        Task<int> UpdateEngineTypeService( EngineType engineType);
        Task DeleteEngineTypeService(int id);
        Task<List<EngineType>> GetAllEngineTypesService();

    }
}
