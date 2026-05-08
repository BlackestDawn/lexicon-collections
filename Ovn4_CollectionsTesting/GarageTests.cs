using Ovn4_Collections.Models;
using Ovn4_Collections.Models.Vehicles;
using Ovn4_Collections.Services;

namespace Ovn4_CollectionsTesting;

public class GarageTests
{
    [Fact]
    public void AddingVehicle()
    {
        Vehicle vehicle = new("ADB123", new FuelEnginesStats(150, 1.7m, FuelTypes.Gasoline), 4, "red");
        Vehicle[] expected = [ vehicle ];
        Garage garage = new(3);

        garage.AddVehicle(vehicle);
        var result = garage.GetAllVehicles();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void BulkAddingVehicles()
    {
        Vehicle[] vehicles = [
            new("ABC123", new FuelEnginesStats(150, 2.0m, FuelTypes.Gasoline), 4, "Red"),
            new("XYZ789", new FuelEnginesStats(320, 3.0m, FuelTypes.Diesel), 4, "Black"),
            new("EV0001", new ElectricEnginesStats(408, 100.0m), 4, "White"),
        ];
        Garage garage = new(5);

        garage.BulkLoadVehicles(vehicles);
        var result = garage.GetAllVehicles();

        Assert.Equal(vehicles, result);
    }
}
