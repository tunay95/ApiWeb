

using APIproject.Repositories.Interface;

namespace APIproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ICarRepository _carRepository;

        public CarController(AppDbContext context,ICarRepository carRepository)
        {
            _context = context;
            _carRepository = carRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cars = await _carRepository.GetAll();
            return StatusCode(StatusCodes.Status200OK, cars);
        }

        [HttpGet]

        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            var cars = await _carRepository.GetByIdAsync(id);
            if (id == null) return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(StatusCodes.Status200OK, cars);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateCarDto CreateCarDto)
        {
            Car car = new Car()
            {
                ModelYear = CreateCarDto.ModelYear,
                DailyPrice = CreateCarDto.DailyPrice,
                Description = CreateCarDto.Description,
                ColourId = CreateCarDto.ColourId,
                BrandId = CreateCarDto.BrandId
               
            };
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, car);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, Car updatedcar)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            var cars = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if (id == null) return StatusCode(StatusCodes.Status404NotFound);


            cars.ModelYear = updatedcar.ModelYear;
            cars.DailyPrice = updatedcar.DailyPrice;
            cars.Description = updatedcar.Description;

            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, cars);

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var car = _context.Cars.Find(id);
            if (car == null) return StatusCode(StatusCodes.Status404NotFound);
            _context.Cars.Remove(car);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }


    }
}
