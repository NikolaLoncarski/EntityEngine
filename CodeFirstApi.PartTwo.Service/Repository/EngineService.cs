using CodeFirstApi.PartTwo.Data;
using CodeFirstApi.PartTwo.Data.Model;
using CodeFirstApi.PartTwo.Interface;
using CodeFirstApi.PartTwo.Model;
using CodeFirstApi.PartTwo.Service.Interface;
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
           var newEngine = await _engineRepository.CreateAsync(engine);

            return newEngine;
        }

        public async Task DeleteEngineService(int id)
        {
            await _engineRepository.DeleteAsync(id);
        }

        public async Task<List<Engine>> GetAllEngineService()
        {
            return await _engineRepository.GetAllAsync();
        }

        public async Task<Engine> GetEngineService(int id)
        {
            return await _engineRepository.GetAsync(id);
        }

        public async Task<int> UpdateEngineService(Engine engine)
        {
          var engineId =  await _engineRepository.UpdateAsync(engine);

            return engineId;
        }
    }
}
