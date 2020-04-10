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
    public class ColumnsController : ControllerBase
    {
        private readonly RocketElevators _context;

        public ColumnsController(RocketElevators context)
        {
            _context = context;
        }

        // GET: api/Columns
        // Return List of all Columns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Columns>>> GetColumns()
        {
            return await _context.Columns.ToListAsync();
        }

        // GET: api/Columns/5
        // Return Status of Specific Column
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetColumnStatus(long id)
        {
            var column = await _context.Columns.FindAsync(id);
            if (column == null)
            {
                return "ID not found";
            }
            return column.ColumnStatus;
        }
        


        // PUT: api/Columns/5
        // Modify status of specific Column 
        [HttpPut("update/status/{id}")]
        public async Task<IActionResult> PutUpdateColumnStatus(long id, string status)
        {
            if (id == null)
            {
                return BadRequest();
            }

            if (status == null)
            {
                return BadRequest();
            }

            var Column = await _context.Columns.FindAsync(id);

            Column.ColumnStatus = status;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColumnsExists(id))
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

        // Return True if specific Column exist else return False
        private bool ColumnsExists(long id)
        {
            return _context.Columns.Any(e => e.Id == id);
        }


        // DELETE: 
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteColumn(long id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var Column = await _context.Columns.FindAsync(id);

            _context.Columns.Remove(Column);

            await _context.SaveChangesAsync();
            return NoContent();
        }
    

        // POST:

        [HttpPost]
        public async Task<ActionResult<Columns>> PostColumns(Columns columns)
        {
            _context.Columns.Add(columns);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColumns", new { id = columns.Id }, columns);
        }

    }
}