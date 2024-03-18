using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstApi.PartTwo.Model
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }

        public int ChasisNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public int? EngineId { get; set; }
        public Engine? Engine { get; set; }
    }
}
