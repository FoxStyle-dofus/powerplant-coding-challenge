using powerplant_coding_challenge.Models;
using powerplant_coding_challenge.Models.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace powerplant_coding_challenge.Service
{
    public class ProductionPlanService : IProductionPlanService
    {

        public ProductionPlanAndMessage GenerateProductionPlan(Payload payload)
        {
            var orderedPowerplants = SortPowerplantByPriceAndPmax(payload);
            return CalculateBestProductionPlan(orderedPowerplants, payload.Fuels, payload.Load);
        }

        public List<Powerplant> SortPowerplantByPriceAndPmax(Payload payload)
        {
            var listOfWindPowerplants = payload.Powerplants.Where(x => x.GetPowerplanFuelType() == FuelType.Wind);
            var sortedListOfPowerplantsWithoutWind = payload.Powerplants.Where(x => x.GetPowerplanFuelType() != FuelType.Wind).OrderBy(x => (decimal) payload.Fuels.GetType().GetProperty(x.GetPowerplanFuelType().ToString()).GetValue(payload.Fuels) / x.Efficiency);
            return listOfWindPowerplants.Concat(sortedListOfPowerplantsWithoutWind).ToList();
        }

        public ProductionPlanAndMessage CalculateBestProductionPlan(List<Powerplant> sortedPowerplants, Fuel fuels, decimal load)
        {
            Regex noMoreThanOneDecimal = new Regex(@"^[0-9]*(\,[0-9]{1})?$");
            bool answerWithMoreThanDecimals = true;
            var calculatedProductionPlan = new ProductionPlanAndMessage();
            foreach(var powerplant in sortedPowerplants)
            {
                decimal powerToTest = powerplant.Pmax;
                while (answerWithMoreThanDecimals && load != 0 && powerToTest > powerplant.Pmin)
                {
                    if(powerplant.GetPowerplanFuelType() == FuelType.Wind)
                    {
                        decimal resultPower = powerToTest * fuels.Wind / 100;
                        if (noMoreThanOneDecimal.Match(resultPower.ToString("G29")).Success && load >= resultPower)
                        {
                            answerWithMoreThanDecimals = false;
                            calculatedProductionPlan.powerplantsUsed.Add(new PowerplantUsed(powerplant.Name, resultPower));
                            load -= resultPower;
                        }
                        else
                        {
                            powerToTest = powerToTest - (decimal) 0.01;
                        }
                    }
                    else
                    {
                        var resultPower = powerToTest * powerplant.Efficiency;
                        if (noMoreThanOneDecimal.Match(resultPower.ToString("G29")).Success && load >= resultPower)
                        {
                            calculatedProductionPlan.powerplantsUsed.Add(new PowerplantUsed(powerplant.Name, resultPower));
                            load -= resultPower;
                            answerWithMoreThanDecimals = false;
                        }
                        else
                        {
                            powerToTest = powerToTest - (decimal) 0.01;
                        }
                    }
                }
                answerWithMoreThanDecimals = true;
            }
                calculatedProductionPlan.message = load == 0 ? "The load has been successfully filled up." : "Impossible to fill the load up.";
            

            return calculatedProductionPlan;
            
        }



    }
}
