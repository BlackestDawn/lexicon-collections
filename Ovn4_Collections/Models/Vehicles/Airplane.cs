using System.Text;
using Ovn4_Collections.Extensions;

namespace Ovn4_Collections.Models.Vehicles;

public class Airplane(VehicleTypes vehicleType, string licenceNumber, int engineCount, IEngine engine, int numWheels, string color)
    : Vehicle(vehicleType, licenceNumber, engine, numWheels, color)
{
    private readonly int _engineCount = engineCount;

  public override string FullDescription()
    {
        StringBuilder sb = new(base.FullDescription());

        sb.InsertLine(1, $"Engine count: {this._engineCount}");

        return sb.ToString();
    }
}
