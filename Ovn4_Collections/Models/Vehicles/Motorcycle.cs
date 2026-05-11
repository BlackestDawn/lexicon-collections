using System.Text;
using Ovn4_Collections.Extensions;

namespace Ovn4_Collections.Models.Vehicles;

public class Motorcycle : Vehicle
{
    private readonly int _maxSpeed;

    public Motorcycle(VehicleTypes vehicleType, string licenceNumber, int maxSpeed, IEngine engine, int numWheels, string color)
        : base(vehicleType, licenceNumber, engine, numWheels, color)
    {
        this._maxSpeed = maxSpeed;
    }

    public override string FullDescription()
    {
        StringBuilder sb = new(base.FullDescription());

        sb.InsertLine(1, $"Top speed: {this._maxSpeed}");

        return sb.ToString();
    }
}
