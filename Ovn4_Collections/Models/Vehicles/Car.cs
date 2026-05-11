using System.Text;
using Ovn4_Collections.Extensions;

namespace Ovn4_Collections.Models.Vehicles;

public class Car : Vehicle
{
    private CarTypes _carType;
    private int _maxSpeed;

    public Car(VehicleTypes vehicleType, string licenceNumber, CarTypes carType, int maxSpeed, IEngine engine, int numWheels, string color)
        : base(vehicleType, licenceNumber, engine, numWheels, color)
    {
        this._carType = carType;
        this._maxSpeed = maxSpeed;
    }
    public override string FullDescription()
    {
        StringBuilder sb = new(base.FullDescription());

        sb.InsertLine(1, $"Class: {this._carType}, Max speed: {this._maxSpeed} km/h");

        return sb.ToString();
    }
}
