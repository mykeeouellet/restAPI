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
    [Route("api/Batteries")]
    [ApiController]
    public class BatteriesController : ControllerBase
    {
        private readonly RocketElevators _context;

        public BatteriesController(RocketElevators context)
        {
            _context = context;
        }

        // GET: api/Batteries 
        // Return List of all Batteries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batteries>>> GetBatteries()
        {
            return await _context.Batteries.ToListAsync();
        }

        // GET: api/Batteries/5
        // Return Status of Specific Battery
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetBatteryStatus(long id)
        {
            var batterie = await _context.Batteries.FindAsync(id);
            if (batterie == null)
            {
                return "ID not found";
            }
            return batterie.BatteryStatus;
        }
 
        // PUT: api/Batteries/5
        // Change Status of Specific Battery
        [HttpPut("update/status/{id}")]
        public async Task<IActionResult> PutUpdateBatteryStatus(long id, string status)
        {

            if (id == null)
            {
                return BadRequest();
            }

            if (status == null)
            {
                return BadRequest();
            }

            var Battery = await _context.Batteries.FindAsync(id);

            Battery.BatteryStatus = status;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatteriesExists(id))
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

        // Return True if specific Battery exist else return False
        private bool BatteriesExists(long id)
        {
            return _context.Batteries.Any(e => e.Id == id);
        }



        // POST: api/Batteries
        [HttpPost]
        public async Task<ActionResult<Batteries>> PostBatteries(Batteries batteries)
        {
            _context.Batteries.Add(batteries);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBatteries", new { id = batteries.Id }, batteries);
        }



        // DELETE: Batteries
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteBattery(long id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var Battery = await _context.Batteries.FindAsync(id);

            _context.Batteries.Remove(Battery);

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}

