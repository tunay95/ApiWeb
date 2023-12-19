namespace APIproject.Entities
{
    public class Colour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Car>? Cars { get; set; }
    }
}
