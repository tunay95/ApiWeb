using APIproject.DAL;
using APIproject.DTOs.BrandDtos;
using APIproject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace APIproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController:ControllerBase
    {
        private readonly AppDbContext _context;
        public BrandController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            List<Brand> brands = await _context.Brands.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, brands);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            var brands = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);
            if (id == null) return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(StatusCodes.Status200OK, brands);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateBrandDto createBrandDto)
        {
            Brand brand = new Brand()
            {
                Name = createBrandDto.Name

            };

            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, brand);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, string name )
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            var brands = await _context.Brands.FirstOrDefaultAsync(c => c.Id == id);
            if (id == null) return StatusCode(StatusCodes.Status404NotFound);

            brands.Name=name;


            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, brands);

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var brand = _context.Brands.Find(id);
            if (brand == null) return StatusCode(StatusCodes.Status404NotFound);
            _context.Brands.Remove(brand);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
