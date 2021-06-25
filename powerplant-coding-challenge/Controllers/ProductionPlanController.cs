using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using powerplant_coding_challenge.Models;
using powerplant_coding_challenge.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace powerplant_coding_challenge.Controllers
{
    [Route("api/productionplan")]
    [ApiController]
    public class ProductionPlanController : ControllerBase
    {
        private readonly IProductionPlanService _productionPlanSerice;
        public ProductionPlanController(IProductionPlanService productionPlanService) => _productionPlanSerice = productionPlanService;

        // POST: api/productionplan
        [HttpPost]
        public async Task<ActionResult<ProductionPlanAndMessage>> CalculateProductionPlan([FromBody] Payload payload)
        {
            return _productionPlanSerice.GenerateProductionPlan(payload);
        }
    }
}
