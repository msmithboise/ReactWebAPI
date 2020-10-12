using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactWebAPI.Models;

namespace ReactWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationCandidatesController : ControllerBase
    {
        private readonly DonationDBContext _context;

        public DonationCandidatesController(DonationDBContext context)
        {
            _context = context;
        }

        // GET: api/DonationCandidates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonationCandidate>>> GetDonationCandidates()
        {
            return await _context.DonationCandidates.ToListAsync();
        }

        // GET: api/DonationCandidates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DonationCandidate>> GetDonationCandidate(int id)
        {
            var donationCandidate = await _context.DonationCandidates.FindAsync(id);

            if (donationCandidate == null)
            {
                return NotFound();
            }

            return donationCandidate;
        }

        // PUT: api/DonationCandidates/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonationCandidate(int id, DonationCandidate donationCandidate)
        {
            //if (id != donationCandidate.id)
            //{
            //    return BadRequest();
            //}

            donationCandidate.id = id;

            _context.Entry(donationCandidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonationCandidateExists(id))
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

        // POST: api/DonationCandidates
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DonationCandidate>> PostDonationCandidate(DonationCandidate donationCandidate)
        {
            _context.DonationCandidates.Add(donationCandidate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonationCandidate", new { id = donationCandidate.id }, donationCandidate);
        }

        // DELETE: api/DonationCandidates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DonationCandidate>> DeleteDonationCandidate(int id)
        {
            var donationCandidate = await _context.DonationCandidates.FindAsync(id);
            if (donationCandidate == null)
            {
                return NotFound();
            }

            _context.DonationCandidates.Remove(donationCandidate);
            await _context.SaveChangesAsync();

            return donationCandidate;
        }

        private bool DonationCandidateExists(int id)
        {
            return _context.DonationCandidates.Any(e => e.id == id);
        }
    }
}
