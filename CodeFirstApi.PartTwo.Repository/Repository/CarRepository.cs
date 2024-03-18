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
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext dbContext;
        public CarRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;

        }

        public async Task<Car> CreateAsync(Car car)
        {
            await dbContext.Cars.AddAsync(car);
            await dbContext.SaveChangesAsync();
            return car;
        }

        public async Task DeleteAsync(int id)
        {
            var carExists = await dbContext.Cars.FirstOrDefaultAsync(x => x.Id == id);

           

            dbContext.Cars.Remove(carExists);
            await dbContext.SaveChangesAsync();
         
        }

        public async Task<List<Car>> GetAllAsync()
        {
            return await dbContext.Cars.ToListAsync();
        }

        public async Task<Car> GetAsync(int id)
        {
            return await dbContext.Cars.Include(e=>e.Engine).ThenInclude(et=>et.EngineTypes).FirstAsync(x => x.Id == id);
        }

        public async Task<int> UpdateAsync( Car car)
        {
           dbContext.Entry(car).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return car.Id;
        }
    }
}
