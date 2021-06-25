using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace powerplant_coding_challenge.Models
{
    public class PowerplantUsed
    {
        public string Name { get; set; }
        public decimal P { get; set; }

        public PowerplantUsed(string name, decimal p)
        {
            Name = name;
            P = p;
        }
    }
}
