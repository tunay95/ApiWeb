namespace APIproject.DTOs.CarDtos
{
    public class CreateCarDto
    {
        public int BrandId { get; set; }
        public int ColourId { get; set; }
        public DateTime ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
