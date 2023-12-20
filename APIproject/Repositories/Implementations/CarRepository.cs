using APIproject.Entities.Base;
using APIproject.Repositories.Interface;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace APIproject.Repositories.Implementations
{
    public class CarRepository<T> : Repository<T> where T : BaseEntity
    {
        public CarRepository(AppDbContext context) : base(context)
        {
        }
    }

}
