using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace powerplant_coding_challenge.Models
{
    public class Payload
    {
        public decimal Load { get; set; }
        public Fuel Fuels { get; set; }
        public List<Powerplant> Powerplants { get; set; }
    }
}
