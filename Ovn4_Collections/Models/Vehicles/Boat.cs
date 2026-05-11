using System.Text;
using Ovn4_Collections.Extensions;

namespace Ovn4_Collections.Models.Vehicles;

public class Boat : Vehicle
{
    private readonly int _engineCount;

    public Boat(VehicleTypes vehicleType, string licenceNumber, int engineCount, IEngine engine, int numWheels, string color)
        : base(vehicleType, licenceNumber, engine, numWheels, color)
    {
        this._engineCount = engineCount;
    }

    public override string FullDescription()
    {
        StringBuilder sb = new(base.FullDescription());

        sb.InsertLine(1, $"Engine count: {this._engineCount}");

        return sb.ToString();
    }
}
