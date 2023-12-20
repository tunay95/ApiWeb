using APIproject.Repositories.Interface;

namespace APIproject.Repositories.Implementations
{
	public class BrandRepository : IBrandRepository
	{
		private readonly AppDbContext _context;
		public BrandRepository(AppDbContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<Brand>> GetAll(params string[] includes)
		{
			var query = await _context.Brands.ToListAsync();
			if(includes is not null)
			{
				query = query.Include();
			}
			return query;
		}

		public async Task<Car> GetByIdAsync(int id)
		{
			return await _context.Brands.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
		}
	}
}

