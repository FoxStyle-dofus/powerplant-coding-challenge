using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using powerplant_coding_challenge.Models.Enums;

namespace powerplant_coding_challenge.Models
{
    public class Powerplant
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Efficiency { get; set; }
        public int Pmin { get; set; }
        public int Pmax { get; set; }

        public FuelType GetPowerplanFuelType()
        {
            switch (this.Type)
            {
                case "gasfired": return FuelType.Gas;
                case "turbojet": return FuelType.Kerosine;
                case "windturbine": return FuelType.Wind;
                default: return FuelType.Gas;
            }
        }

    }

}