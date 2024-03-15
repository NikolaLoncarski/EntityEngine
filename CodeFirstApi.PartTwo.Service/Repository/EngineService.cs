using CodeFirstApi.PartTwo.Data;
using CodeFirstApi.PartTwo.Interface;
using CodeFirstApi.PartTwo.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstApi.PartTwo.Service.Repository
{
    public class EngineService : IEngineService


    {

         private readonly IEngineRepository _engineRepository;
        public EngineService(IEngineRepository engineRepository)
        {
            _engineRepository = engineRepository;
        }

        public async Task<Engine> CreateEngineService(Engine engine)
        {
            return await _engineRepository.CreateAsync(engine);
        }

        public async Task<Engine> DeleteEngineService(int id)
        {
            return await _engineRepository.DeleteAsync(id);
        }

        public async Task<Engine> GetEngineService(int id)
        {
            return await _engineRepository.GetAsync(id);
        }

        public async Task UpdateEngineService(Engine engine)
        {
            await _engineRepository.UpdateAsync(engine);
        }
    }
}
