using System.Collections;
using Ovn4_Collections.Models;
using Ovn4_Collections.Models.Vehicles;

namespace Ovn4_Collections.Services;

public class Garage
{
    private int _maxSpace;
    private int _usedSpace = 0;
    private Vehicle[] _vehicles;
    private Hashtable _amountByType;
    public Hashtable AmountsByVehicleType
    {
        get => this._amountByType;
    }

    public Garage(int maxSpace)
    {
        this._maxSpace = maxSpace;
        this._vehicles = new Vehicle[maxSpace];
        this._amountByType = new Hashtable();
        foreach (var type in Enum.GetValues<VehicleTypes>())
        {
            this._amountByType.Add(type, 0);
        }
    }

    public Vehicle[] GetAllVehicles()
    {
        Vehicle[] parkedVehicles = new Vehicle[this._usedSpace];
        int index = 0;
        foreach (var vehicle in this._vehicles)
        {
            if (vehicle != null)
            {
                parkedVehicles[index] = vehicle;
                index++;
            }
        }
        return parkedVehicles;
    }

    public string[] GetAllLicenceNumbers()
    {
        string[] licenceNumbers = new string[this._usedSpace];
        int index = 0;
        foreach (var vehicle in this._vehicles)
        {
            if (vehicle != null)
            {
                licenceNumbers[index] = vehicle.LicenceNumber;
                index++;
            }
        }
        return licenceNumbers;
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
                var vehicleType = vehicle.VehicleType;
                this._amountByType[vehicleType] = (int)this._amountByType[vehicleType] + 1;
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
            if (this._vehicles[i] != null && this._vehicles[i].LicenceNumber.ToLower() == licenceNumber.ToLower())
            {
                var vehicleType = this._vehicles[i].VehicleType;
                this._amountByType[vehicleType] = (int)this._amountByType[vehicleType] - 1;
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
