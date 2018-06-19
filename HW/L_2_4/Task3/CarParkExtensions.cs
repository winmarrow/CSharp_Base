using System;
using System.Collections.Generic;
using System.Linq;

namespace L_2_4.Task3
{
    public static class CarParkExtensions
    {
        public static List<Car> SelectCars(this CarPark carPark, Func<Car, bool> selector)
        {
            return carPark.Cars.Where(selector).ToList();
        }

        public static void SortCars(this CarPark carPark, Comparison<Car> compareFunc)
        {
            carPark.Cars.Sort(compareFunc);
        }
    }
}