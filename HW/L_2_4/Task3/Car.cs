using System;

namespace L_2_4.Task3
{
    public abstract class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ReleasedYead { get; set; }
        public decimal Price { get; set; }

        public static bool IsValid(Car car)
        {
            return car != null
                   && !string.IsNullOrWhiteSpace(car.Brand)
                   && !string.IsNullOrWhiteSpace(car.Model)
                   && car.ReleasedYead >= 1900
                   && car.ReleasedYead <= DateTime.Now.Year
                   && car.Price > 0M;
        }
    }
}