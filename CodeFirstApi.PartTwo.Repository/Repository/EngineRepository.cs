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
   public class EngineRepository : IEngineRepository


    {
        private readonly AppDbContext dbContext;


        public EngineRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> CreateAsync(Engine engine)
        {
            await dbContext.Engines.AddAsync(engine);
            await dbContext.SaveChangesAsync();
            return engine.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var engineExist = await dbContext.Engines.FirstOrDefaultAsync(x => x.Id == id);

          

            dbContext.Engines.Remove(engineExist);
            await dbContext.SaveChangesAsync();
          
        }

        public async Task<List<Engine>> GetAllAsync()
        {
            return await dbContext.Engines.ToListAsync();
        }

        public async Task<Engine> GetAsync(int id)
        {
            return await dbContext.Engines.FirstAsync(x => x.Id == id);
        }

        public async Task<int> UpdateAsync(Engine engine)
        {
            dbContext.Entry(engine).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return engine.Id;
        }
    }
}
