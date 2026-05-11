namespace Ovn4_Collections.Models.Vehicles;

public class Vehicle(VehicleTypes vehicleType, string licenceNumber, IEngine engine, int numWheels, string color)
{
    private VehicleTypes _vehicleType = vehicleType;
    public VehicleTypes VehicleType
    {
        get => this._vehicleType;
    }
    private string _licenceNumber = licenceNumber;
    public string LicenceNumber
    {
        get => _licenceNumber;
    }
    private IEngine _engine = engine;
    private int _numWheels = numWheels;
    private string _color = color;

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
}
