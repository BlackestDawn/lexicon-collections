using System.Text;
using Ovn4_Collections.Extensions;

namespace Ovn4_Collections.Models.Vehicles;

public class Bus(VehicleTypes vehicleType, string licenceNumber, int passangerCapacity, IEngine engine, int numWheels, string color)
    : Vehicle(vehicleType, licenceNumber, engine, numWheels, color)
{
    private readonly int _passengerCapacity = passangerCapacity;

  public override string FullDescription()
    {
        StringBuilder sb = new(base.FullDescription());

        sb.InsertLine(1, $"Passenger capacity: {this._passengerCapacity}");

        return sb.ToString();
    }
}
