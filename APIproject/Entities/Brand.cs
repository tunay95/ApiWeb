using APIproject.Entities.Base;

namespace APIproject.Entities
{
    public class Brand:BaseEntity
    {
        public string Name { get; set; }
        public List<Car>? Cars { get; set; }
    }
}
