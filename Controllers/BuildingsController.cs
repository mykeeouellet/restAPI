using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_Rest_Api.Models;
using Newtonsoft.Json.Linq;

namespace Rocket_Elevators_Rest_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly RocketElevators _context;

        public BuildingsController(RocketElevators context)
        {
            _context = context;
        }

        // GET: api/Buildings
        // Return List of Buildings needs intervention
        [HttpGet]
        public ActionResult<List<Buildings>> GetToFixBuildings()
        {
            IQueryable<Buildings> ToFixBuildingsList = from ObjectStatus in _context.Buildings
            join batteries in _context.Batteries on ObjectStatus.Id equals batteries.BuildingId
            join columns in _context.Columns on batteries.Id equals columns.BatteryId
            join elevators in _context.Elevators on columns.Id equals elevators.ColumnId
            where (batteries.BatteryStatus == "Intervention") || (columns.ColumnStatus == "Intervention") || (elevators.ElevatorStatus == "Intervention")
            select ObjectStatus;
            return ToFixBuildingsList.Distinct().ToList();
        }
    }
}
