﻿namespace APIproject.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColourId { get; set; }
        public DateTime ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public Brand? Brand { get; set; }
        public Colour? Colour { get; set; }
    }
}
