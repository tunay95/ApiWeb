

using APIproject.Repositories.Interface;

namespace APIproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
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
        public async Task<IActionResult> Create([FromForm] CreateCarDto CreateCarDto)
        {
            Car car = new Car()
            {
                ModelYear = CreateCarDto.ModelYear,
                DailyPrice = CreateCarDto.DailyPrice,
                Description = CreateCarDto.Description,
                ColourId = CreateCarDto.ColourId,
                BrandId = CreateCarDto.BrandId

            };
            await _carRepository.Create(car);
            await _carRepository.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, car);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, Car updatedcar)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            var cars = await _carRepository.GetByIdAsync(id);
            if (id == null) return StatusCode(StatusCodes.Status404NotFound);


            cars.ModelYear = updatedcar.ModelYear;
            cars.DailyPrice = updatedcar.DailyPrice;
            cars.Description = updatedcar.Description;

            _carRepository.Update(cars);
            await _carRepository.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, cars);

        }

        //[HttpDelete]
        //[Route("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var car = _carRepository.Cars.FirstOrDefault(c => c.Id == id);
        //    ;
        //    await _carRepository.SaveChangesAsync();
        //    return StatusCode(StatusCodes.Status200OK);
        //}


    }
}
