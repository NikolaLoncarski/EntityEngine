using CodeFirstApi.PartTwo.Model;

namespace CodeFirstApi.PartTwo.Interface
{
    public interface IEngineService
    {
        Task<int> CreateEngineService(Engine engine);

        Task<Engine> GetEngineService(int id);
        Task<int> UpdateEngineService( Engine engine);
        Task DeleteEngineService(int id);
        Task<List<Engine>> GetAllEngineService();

    }
}
