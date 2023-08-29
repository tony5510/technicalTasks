using System;
using System.Collections.Generic;

public delegate void WashingDelegate(Car car);

class Program
{
    static void Main(string[] args)
    {
        Car car1 = new Car("Ford Mustang GTR");
        Car car2 = new Car("Lada Vesta");
        Car car3 = new Car("Ford Focus");

        Garage garage = new Garage();
        garage.AddCar(car1);
        garage.AddCar(car2);
        garage.AddCar(car3);

        Wash wash = new Wash();

        WashingDelegate washingDelegate = new WashingDelegate(wash.WashCars);

        garage.WashAllCars(washingDelegate);
    }
}