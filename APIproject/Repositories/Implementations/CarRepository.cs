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
        public async Task<IEnumerable<Car>> GetAll(params string[] includes)
        {
            IQueryable<Car> query =  _context.Cars;
            if(includes is not null)
            {
                for(int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            return query;
        }

		public Task<IQueryable<Car>> GetAll()
		{
			throw new NotImplementedException();
		}

		public async Task<Car> GetByIdAsync(int id)
        {
            return await _context.Cars.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
