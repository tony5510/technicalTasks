public class Garage
{
    private List<Car> _cars = new List<Car>();

    public void AddCar(Car car)
    {
        _cars.Add(car);
    }

    public void WashAllCars(WashingDelegate washDelegate)
    {
        foreach (var car in _cars)
        {
            washDelegate(car);
        }
    }
}
