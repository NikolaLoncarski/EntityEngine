using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstApi.PartTwo.Service.Dto
{
  public class CarRequestDTO
    {
        public string Color { get; set; }
        public int Year { get; set; }

        public int ChasisNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

   
    }
}
