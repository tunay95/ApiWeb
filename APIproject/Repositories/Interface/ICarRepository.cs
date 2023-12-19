namespace APIproject.Repositories.Interface
{
    public interface ICarRepository
    {
        
        Task<IEnumerable<Car>> GetAll();
        Task<Car>GetByIdAsync(int id);
    }
}
