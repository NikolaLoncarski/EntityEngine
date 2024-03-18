using CodeFirstApi.PartTwo.Data;
using CodeFirstApi.PartTwo.Interface;
using CodeFirstApi.PartTwo.Model;
using CodeFirstApi.PartTwo.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstApi.PartTwo.Repository.Repository
{
   public class EngineTypeRepository : IEngineTypeRepository
    {

        private readonly AppDbContext dbContext;
        public EngineTypeRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<EngineType> CreateAsync(EngineType engineType)
        {
            await dbContext.EngineTypes.AddAsync(engineType);
            await dbContext.SaveChangesAsync();
            return engineType;
        }

        public async Task DeleteAsync(int id)
        {
            var existingEngineType = await dbContext.EngineTypes.FirstOrDefaultAsync(x => x.Id == id);

         
            dbContext.EngineTypes.Remove(existingEngineType);
            await dbContext.SaveChangesAsync();
        
        }

        public async Task<List<EngineType>> GetAllAsync()
        {
            return await dbContext.EngineTypes.ToListAsync();
        }

        public async Task<EngineType> GetAsync(int id)
        {
            return await dbContext.EngineTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> UpdateAsync( EngineType engineType)
        {
          var updatedEngineType = dbContext.Entry(engineType).State = EntityState.Modified;

            try
            {
                dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return engineType.Id    ;

        }
    }
}
