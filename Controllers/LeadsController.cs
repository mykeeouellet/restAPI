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
    public class LeadsController : ControllerBase
    {
        private readonly RocketElevators _context;

        public LeadsController(RocketElevators context)
        {
            _context = context;
        }
        
        // GET api/leads
        // Return Leads created in the last 30 days who have not yet become customers
        [HttpGet]
        public ActionResult<IEnumerable<Leads>> GetNoCustomerLead () 
        {
            List<Leads> LeadsList = _context.Leads.ToList();
            List<Leads> NoCustomerLeadsList = new List<Leads>();
            foreach (var lead in LeadsList)
            {
                if ((DateTime.Now - lead.CreatedAt).TotalDays < 30)
                {
                    bool exists = _context.Customers.AsEnumerable().Where(c => c.CompanyName.Equals(lead.LeadCompanyName)).Count() > 0;
                    if (!exists)
                    {
                        NoCustomerLeadsList.Add(lead);
                    }
                }
            }
            return NoCustomerLeadsList.ToList();
        }

        // GET: api/Leads/5
        // Return a specific Lead
        [HttpGet("{id}")]
        public async Task<ActionResult<Leads>> GetLeads(long id)
        {
            var leads = await _context.Leads.FindAsync(id);

            if (leads == null)
            {
                return NotFound();
            }

            return leads;
        }

        // PUT: api/Leads/5
        // Update a specific Lead
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeads(long id, Leads leads)
        {
            if (id != leads.Id)
            {
                return BadRequest();
            }

            _context.Entry(leads).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadsExists(id))
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

        // POST: api/Leads
        //  Create a new Lead
        [HttpPost]
        public async Task<ActionResult<Leads>> PostLeads(Leads leads)
        {
            _context.Leads.Add(leads);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeads", new { id = leads.Id }, leads);
        }

        // DELETE: api/Leads/5
        // Delete a specific Lead
        [HttpDelete("{id}")]
        public async Task<ActionResult<Leads>> DeleteLeads(long id)
        {
            var leads = await _context.Leads.FindAsync(id);
            if (leads == null)
            {
                return NotFound();
            }

            _context.Leads.Remove(leads);
            await _context.SaveChangesAsync();

            return leads;
        }

        // Return True if specific Lead exist else return False
        private bool LeadsExists(long id)
        {
            return _context.Leads.Any(e => e.Id == id);
        }
    }
}
