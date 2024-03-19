using CodeFirstApi.PartTwo.Data.Model;
using CodeFirstApi.PartTwo.Model;

namespace CodeFirstApi.PartTwo.Service.Interface
{
    public interface IEngineService
    {
        Task<Engine> CreateEngineService(Engine engine);

        Task<Engine> GetEngineService(int id);
        Task<int> UpdateEngineService( Engine engine);
        Task DeleteEngineService(int id);
        Task<List<Engine>> GetAllEngineService();

    }
}
