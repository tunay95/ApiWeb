using APIproject.Repositories.Interface;

namespace APIproject.Repositories.Implementations
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _context;
        public CarRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Car>> GetAll()
        {
            var query = await _context.Cars.ToListAsync();
            return query;
        }

        public Task<Car> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
