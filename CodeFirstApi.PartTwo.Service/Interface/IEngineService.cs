using CodeFirstApi.PartTwo.Model;

namespace CodeFirstApi.PartTwo.Interface
{
    public interface IEngineService
    {
        Task<Engine> CreateEngineService(Engine engine);

        Task<Engine> GetEngineService(int id);
        Task UpdateEngineService( Engine engine);
        Task<Engine> DeleteEngineService(int id);

    }
}
