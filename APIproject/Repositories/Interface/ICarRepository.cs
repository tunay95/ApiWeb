namespace APIproject.Repositories.Interface
{
    public interface ICarRepository
    {
        
        Task<IQueryable<Car>> GetAll();
        Task<Car>GetByIdAsync(int id);
    }
}
