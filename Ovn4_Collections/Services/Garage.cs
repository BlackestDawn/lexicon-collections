using Ovn4_Collections.Models.Vehicles;

namespace Ovn4_Collections.Services;

public class Garage(int maxSpace)
{
    private int _maxSpace = maxSpace;
    private Vehicle[] _vehicles = new Vehicle[maxSpace];

    public void ListAllVehicles()
    {
        throw new NotImplementedException();
    }

    public void ListVehicleAmountByType()
    {
        throw new NotImplementedException();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        throw new NotImplementedException();
    }

    public void RemoveVehicle(string licenceNumber)
    {
        throw new NotImplementedException();
    }

    public void BulkLoadVehicles(Vehicle[] vehicles)
    {
        throw new NotImplementedException();
    }

    public Vehicle FindByLicenceNumber(string licenceNumber)
    {
        throw new NotImplementedException();
    }
}
