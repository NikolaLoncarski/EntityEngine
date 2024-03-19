using CodeFirstApi.PartTwo.Data.Model;
using CodeFirstApi.PartTwo.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace CodeFirstApi.PartTwo.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Engine> Engines { get; set; }

        public DbSet<EngineType> EngineTypes { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Engine>()
         .HasMany(e => e.EngineTypes)
         .WithOne(e => e.Engine)
         .HasForeignKey(e=>e.EngineId)
         .IsRequired(false);







            modelBuilder.Entity<Car>().HasData(
            new Car
            {
                Id = 1,
                Model = "Yugo",
                Color = "red",
                ChasisNumber = 1992,
                Brand = "Zastava",
                Year = 1980,
                EngineId = 1
            },
              new Car
              {
                  Id = 2,
                  Model = "Yugo",
                  Color = "red",
                  ChasisNumber = 1992,
                  Brand = "Zastava",
                  Year = 1980,
                  EngineId = 2
              });
            modelBuilder.Entity<Engine>().HasData(
       new Engine
       {
           Id = 1,

           SerialNumber = 1992,
           Brand = "E115",
           Year = 1980,

       },
       new Engine
       {
           Id = 2,

           SerialNumber = 1992,
           Brand = "F1215",
           Year = 1980,



       });

            modelBuilder.Entity<EngineType>().HasData(
              new EngineType
              {
                  Id = 1,

                  Name = "O1123",
                  Model = "O1215",
                  EngineId= 1,


              },
              new EngineType
              {
                  Id = 2,

                  Name = "F1123",
                  Model = "F1215",
                  EngineId = 1,


              });


            base.OnModelCreating(modelBuilder);
        }


    }
}
