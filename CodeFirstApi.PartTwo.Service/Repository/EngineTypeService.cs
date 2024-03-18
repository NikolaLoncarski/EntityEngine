
using CodeFirstApi.PartTwo.Interface;
using CodeFirstApi.PartTwo.Model;
using CodeFirstApi.PartTwo.Repository.Interface;
using CodeFirstApi.PartTwo.Repository.Repository;
using CodeFirstApi.PartTwo.Service.Interface;
using CodeFirstApi.PartTwo.Service.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstApi.PartTwo.Service.Repository
{
    public class EngineTypeService : IEngineTypeService
    {

       private readonly IEngineTypeRepository engineTypeRepository;


        public EngineTypeService (IEngineTypeRepository engineTypeRepository)
        {
            this.engineTypeRepository = engineTypeRepository;
        }
        public async Task<EngineType> CreateEngineTypeService(EngineType engineType)
        {
           return await engineTypeRepository.CreateAsync(engineType);
        }

        public async Task DeleteEngineTypeService(int id)
        {
          await engineTypeRepository.DeleteAsync(id);
        }

        public async Task<List<EngineType>> GetAllEngineTypesService()
        {
            return await engineTypeRepository.GetAllAsync();
        }

        public Task<EngineType> GetEngineTypeService(int id)
        {
          return engineTypeRepository.GetAsync(id);
        }

        public async Task<int> UpdateEngineTypeService(EngineType engineType)
        {
          int updatedId=    await engineTypeRepository.UpdateAsync(engineType);

            return updatedId;
        }
    }
}
