using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstApi.PartTwo.Service.ExternalAPI.Model
{
    public class CarModel
    {
        public int id { get; set; }
        public int make_id { get; set; }
        public string name { get; set; }
        public Make make { get; set; }
    }
}
