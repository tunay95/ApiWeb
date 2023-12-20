using APIproject.Repositories.Interface;
using System.Linq.Expressions;

namespace APIproject.Repositories.Implementations
{
	public class BrandRepository : IBrandRepository
	{
		private readonly AppDbContext _context;
		public BrandRepository(AppDbContext context)
		{
			_context = context;
		}
		public async Task<IQueryable<Brand>> GetAll( Expression<Func<Brand,bool>>? expression=null,params string[] includes)
		{
            IQueryable<Brand> query = _context.Brands;
            if (includes is not null)
			{
				for(int i = 0; i < includes.Length; i++)
				{
				    query = query.Include(includes[i]);
				}
			}
			return query;
		}

		public async Task<Brand> GetByIdAsync(int id)
		{
			return await _context.Brands.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
		}
	}
}

