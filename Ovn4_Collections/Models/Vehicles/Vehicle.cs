using System.Text;

namespace Ovn4_Collections.Models.Vehicles;

public class Vehicle(VehicleTypes vehicleType, string licenceNumber, IEngine engine, int numWheels, string color)
{
    private readonly VehicleTypes _vehicleType = vehicleType;
    public VehicleTypes VehicleType
    {
        get => this._vehicleType;
    }
    private readonly string _licenceNumber = licenceNumber;
    public string LicenceNumber
    {
        get => _licenceNumber;
    }
    private readonly IEngine _engine = engine;
    private readonly int _numWheels = numWheels;
    private readonly string _color = color;

    public override string ToString()
    {
        return $"Licence number: {this._licenceNumber}\nEngine: {this._engine.Description}\nColor: {this._color}";
    }

    public override bool Equals(object? obj)
        {
            if (obj is not Vehicle other) return false;
            return LicenceNumber == other.LicenceNumber;
        }

    public override int GetHashCode() => LicenceNumber.GetHashCode();

    public string MinimalDescription()
    {
        return $"Licence: {this._licenceNumber}, Type: {this._vehicleType}";
    }

    public virtual string FullDescription()
    {
        StringBuilder sb = new();

        string wheelsDescriptionPart = this._numWheels > 0 ? $", Wheels: {this._numWheels}" : "";
        sb.AppendLine(this.MinimalDescription());
        sb.AppendLine($"Color: {this._color}{wheelsDescriptionPart}");
        sb.AppendLine($"Engine: {this._engine.Description}");

        return sb.ToString();
    }
}
