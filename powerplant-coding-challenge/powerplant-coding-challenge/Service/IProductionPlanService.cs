using powerplant_coding_challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace powerplant_coding_challenge.Service
{
    public interface IProductionPlanService
    {
        public ProductionPlanAndMessage GenerateProductionPlan(Payload payload);
        public List<Powerplant> SortPowerplantByPriceAndPmax(Payload payload);
        public ProductionPlanAndMessage CalculateBestProductionPlan(List<Powerplant> powerplants, Fuel fuels, decimal load);
    }
}
