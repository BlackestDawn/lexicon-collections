namespace Ovn4_Collections.Models.Vehicles;

public class Vehicle(string licenceNumber, IEngineStats engine, int numWheels, string color)
{
    private string _licenceNumber = licenceNumber;
    public string LicenceNumber
    {
        get => _licenceNumber;
    }
    private IEngineStats _engine = engine;
    private int _numWheels = numWheels;
    private string _color = color;
}
