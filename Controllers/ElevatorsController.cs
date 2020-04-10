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
    [Route("api/[controller]")]
    [ApiController]
    public class ElevatorsController : ControllerBase
    {
        private readonly RocketElevators _context;

        public ElevatorsController(RocketElevators context)
        {
            _context = context;
        }

        // GET: api/Elevators/5
        // Return Status of Specific Elevator
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetElevatorStatus(long id)
        {
            var elevator = await _context.Elevators.FindAsync(id);
            if (elevator == null)
            {
                return "ID not found";
            }
            return elevator.ElevatorStatus;
        }

        // GET: api/Elevators 
        // Return List of Inactive Elevators
        [HttpGet]
        public  ActionResult<IEnumerable<Elevators>> GetInactiveElevators()
        {
            List<Elevators> InactiveElevatorsList = new List<Elevators>();
            foreach (var Elevator in _context.Elevators)
            {
                if (Elevator.ElevatorStatus != "Active")
                {
                    InactiveElevatorsList.Add(Elevator);
                }
            }
            return InactiveElevatorsList.ToList();
        }

        // PUT: api/Elevators/5
        // Update Status of specific Elevator 
        [HttpPut("update/status/{id}")]
        public async Task<IActionResult> PutUpdateElevatorStatus(long id, string status)
        {
            if (status == null)
            {
                return BadRequest();
            }

            var Elevator = await _context.Elevators.FindAsync(id);

            Elevator.ElevatorStatus = status;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElevatorsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // Return True if specific Elevator exist else return False
        private bool ElevatorsExists(long id)
        {
            return _context.Elevators.Any(e => e.Id == id);
        }
    }
}
