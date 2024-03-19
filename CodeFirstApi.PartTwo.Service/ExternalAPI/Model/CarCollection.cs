using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstApi.PartTwo.Service.ExternalAPI.Model
{
    public class CarCollection
    {
        public string url { get; set; }
        public int count { get; set; }
        public int pages { get; set; }
        public int total { get; set; }
        public string next { get; set; }
        public string prev { get; set; }
        public string first { get; set; }
        public string last { get; set; }
    }
}
