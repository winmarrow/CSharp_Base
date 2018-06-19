using System;
using System.Collections.Generic;

namespace L_2_4.Task3
{
    public class CarPark
    {
        public List<Car> Cars { get; set; }
        public Action<Car> AddNewCarAction { get; set; }


        public void AddCar(Car car)
        {
            if (!Car.IsValid(car)) return;

            Cars.Add(car);
            AddNewCarAction?.Invoke(car);
        }
    }
}
