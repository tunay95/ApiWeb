using APIproject.DAL;
using APIproject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColourController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ColourController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Colour> colours = await _context.Colours.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, colours);
        }

        [HttpGet]

        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            var colours = await _context.Colours.FirstOrDefaultAsync(c => c.Id == id);
            if (id == null) return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(StatusCodes.Status200OK, colours);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Colour colour)
        {
            _context.Colours.AddAsync(colour);
            _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, colour);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, string name)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            var colours = await _context.Colours.FirstOrDefaultAsync(c => c.Id == id);
            if (id == null) return StatusCode(StatusCodes.Status404NotFound);

            colours.Name = name;
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, colours);
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var colour = _context.Colours.Find(id);
            if (colour == null) return StatusCode(StatusCodes.Status404NotFound);
            _context.Colours.Remove(colour);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }

    }
}

