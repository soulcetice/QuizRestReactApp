using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DQuestionController : ControllerBase
    {
        private readonly QuizDBContext _context;

        public DQuestionController(QuizDBContext context)
        {
            _context = context;
        }

        // GET: api/DQuestion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DQuestion>>> GetDQuestions()
        {
            return await _context.DQuestions.ToListAsync();
        }

        // GET: api/DQuestion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DQuestion>> GetDQuestion(int id)
        {
            var dQuestion = await _context.DQuestions.FindAsync(id);

            if (dQuestion == null)
            {
                return NotFound();
            }

            return dQuestion;
        }

        // PUT: api/DQuestion/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDQuestion(int id, DQuestion dQuestion)
        {
            dQuestion.id = id;

            _context.Entry(dQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DQuestionExists(id))
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

        // POST: api/DQuestion
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DQuestion>> PostDQuestion(DQuestion dQuestion)
        {
            _context.DQuestions.Add(dQuestion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDQuestion", new { id = dQuestion.id }, dQuestion);
        }

        // DELETE: api/DQuestion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DQuestion>> DeleteDQuestion(int id)
        {
            var dQuestion = await _context.DQuestions.FindAsync(id);
            if (dQuestion == null)
            {
                return NotFound();
            }

            _context.DQuestions.Remove(dQuestion);
            await _context.SaveChangesAsync();

            return dQuestion;
        }

        private bool DQuestionExists(int id)
        {
            return _context.DQuestions.Any(e => e.id == id);
        }
    }
}
