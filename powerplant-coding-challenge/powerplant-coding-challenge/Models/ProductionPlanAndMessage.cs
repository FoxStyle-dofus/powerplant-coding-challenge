using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace powerplant_coding_challenge.Models
{
    public class ProductionPlanAndMessage
    {
        public string message { get; set; }
        public List<PowerplantUsed> powerplantsUsed { get; set; }
        public ProductionPlanAndMessage()
        {
            powerplantsUsed = new List<PowerplantUsed>();
        }
    }
}
