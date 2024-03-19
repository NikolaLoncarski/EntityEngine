using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstApi.PartTwo.Service.ExternalAPI.Model
{
    public class RootObject
    {
        public CarCollection collection { get; set; }
        public List<CarModel> data { get; set; }
    }
}
