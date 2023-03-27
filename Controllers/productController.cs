using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product2.Models;

namespace myapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productController : ControllerBase
    {
        private readonly ProductContext _context;

        public productController(ProductContext context)
        {
            _context = context;
            if (!_context.TodoItems.Any())
            {

                var Webitems = new List<Productitems>
                {

                    new Productitems { Id = 001,Name = "Laptop" ,PName ="Dell" },
                    new Productitems { Id = 002,Name = "Mobile",PName ="Oppo"  },
                    new Productitems { Id = 003,Name = "Tablets",PName ="iPad"  },
                    new Productitems { Id = 004,Name = "Furniture",PName ="Table"  },

                 };
                _context.TodoItems.AddRange(Webitems);
                _context.SaveChangesAsync();

            }
        }

        // GET: api/webitems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productitems>>> GetTodoItems()
        {
          if (_context.TodoItems == null)
          {
              return NotFound();
          }
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/webitems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Productitems>> Getwebitems(long id)
        {
          if (_context.TodoItems == null)
          {
              return NotFound();
          }
            var Webitems = await _context.TodoItems.FindAsync(id);

            if (Webitems == null)
            {
                return NotFound();
            }

            return Webitems;
        }

        // PUT: api/webitems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWebitems(long id, Productitems Webitems)
        {
            if (id != Webitems.Id)
            {
                return BadRequest();
            }

            _context.Entry(Webitems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!webitemsExists(id))
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

        // POST: api/webitems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Productitems>> Postwebitems(Productitems webitems)
        {
          if (_context.TodoItems == null)
          {
              return Problem("Entity set 'WebContext.TodoItems'  is null.");
          }
            _context.TodoItems.Add(webitems);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Getwebitems), new { id = webitems.Id }, webitems);
        }

        // DELETE: api/webitems/5

        [HttpDelete()]
        [Route("DeleteWebitems/{id:long}")]
        public async Task<IActionResult> DeleteWebitems(long id)
        {
            if (_context.TodoItems == null)
            {
                return NotFound();
            }
            var webitems = await _context.TodoItems.FindAsync(id);
            if (webitems == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(webitems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool webitemsExists(long id)
        {
            return (_context.TodoItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
