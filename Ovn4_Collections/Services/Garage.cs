using Ovn4_Collections.Models.Vehicles;

namespace Ovn4_Collections.Services;

public class Garage(int maxSpace)
{
    private int _maxSpace = maxSpace;
    private int _usedSpace = 0;
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
        if (this._usedSpace == this._maxSpace)
        {
            throw new ArgumentException("Space is full");
        }
        for (int i = 0; i < this._maxSpace; i++)
        {
            if (this._vehicles[i] == null)
            {
                this._vehicles[i] = vehicle;
                this._usedSpace++;
                return;
            }
        }
    }

    public void RemoveVehicle(string licenceNumber)
    {
        if (this._usedSpace == 0)
        {
            throw new ArgumentException("Space is empty");
        }
        for (int i = 0; i < this._maxSpace; i++)
        {
            if (this._vehicles[i].LicenceNumber.ToLower() == licenceNumber.ToLower())
            {
                this._vehicles[i] = null;
                this._usedSpace--;
                return;
            }
        }
        throw new ArgumentException($"Vehicle with number {licenceNumber} not found");
    }

    public void BulkLoadVehicles(Vehicle[] vehicles)
    {
        try {
            foreach (var vehicle in vehicles)
            {
                this.AddVehicle(vehicle);
            }
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException($"Could not load all vehicles: {ex.Message}");
        }
    }

    public Vehicle FindByLicenceNumber(string licenceNumber)
    {
        throw new NotImplementedException();
    }
}
