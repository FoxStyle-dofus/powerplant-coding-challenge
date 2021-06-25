using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace powerplant_coding_challenge.Models.Enums
{
    public enum PowerplantType
    {
        [EnumMember(Value = "gasfired")]
        Gasfired = 0,
        [EnumMember(Value = "turbojet")]
        Turbojet = 1,
        [EnumMember(Value = "windturbine")]
        Windturbine = 2
    }
}
