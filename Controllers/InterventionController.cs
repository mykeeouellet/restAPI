using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_Rest_Api.Models;

namespace Rocket_Elevators_Rest_Api.Controllers
{
    [Route("api/intervention")]
    [ApiController]
    public class InterventionController : ControllerBase
    {
        private readonly RocketElevators _context;

        public InterventionController(RocketElevators context)
        {
            _context = context;
        }

        
        [HttpGet("pending")]
        public async Task<ActionResult<IEnumerable<Interventions>>> GetInterventionPending()
        {

           var intervention = _context.Interventions.AsEnumerable().Where(c => c.status.Equals("Pending") && c.intervention_starting_date_time == null);

            if (intervention == null || !intervention.Any())
            {
                return NotFound();
            }

            return intervention.ToList();
        }

        [HttpPut("update/{id}/status")]
        public async Task<IActionResult> Putchangestatusdatetime(long id)
        {
            
            try
            {
                var intervention = await _context.Interventions.FindAsync(id);

                intervention.status = "InProgress";
                intervention.intervention_starting_date_time = DateTime.Now;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("update/{id}/statuscomplete")]
        public async Task<IActionResult> Putstatustocomplete(long id)
        {
           
            try
            {
                var intervention = await _context.Interventions.FindAsync(id);

                intervention.status = "Completed";
                intervention.intervention_ending_date_time = DateTime.Now;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}

