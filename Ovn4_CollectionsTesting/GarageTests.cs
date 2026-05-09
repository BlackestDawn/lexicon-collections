using Ovn4_Collections.Models;
using Ovn4_Collections.Models.Vehicles;
using Ovn4_Collections.Services;

namespace Ovn4_CollectionsTesting;

public class GarageTests
{
    [Fact]
    public void AddingVehicle()
    {
        Vehicle vehicle = new(VehicleTypes.Car, "EV0001", new ElectricEngine(408, 100.0m), 4, "White");
        Vehicle[] expected = [ new(VehicleTypes.Car, "EV0001", new ElectricEngine(408, 100.0m), 4, "White") ];
        Garage garage = new(3);

        garage.AddVehicle(vehicle);
        var result = garage.GetAllVehicles();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void BulkAddingVehicles()
    {
        Vehicle[] vehicles = [
            new(VehicleTypes.Car, "EV0001", new ElectricEngine(408, 100.0m), 4, "White"),
            new(VehicleTypes.Motorcycle, "BIKE42", new FuelEngine(85, 0.6m, FuelTypes.Gasoline), 2, "Blue"),
            new(VehicleTypes.Bus, "TRK999", new FuelEngine(500, 12.7m, FuelTypes.Diesel), 18, "Orange"),
        ];
        Vehicle[] expected = [
            new(VehicleTypes.Car, "EV0001", new ElectricEngine(408, 100.0m), 4, "White"),
            new(VehicleTypes.Motorcycle, "BIKE42", new FuelEngine(85, 0.6m, FuelTypes.Gasoline), 2, "Blue"),
            new(VehicleTypes.Bus, "TRK999", new FuelEngine(500, 12.7m, FuelTypes.Diesel), 18, "Orange"),
        ];
        Garage garage = new(5);

        garage.BulkLoadVehicles(vehicles);
        var result = garage.GetAllVehicles();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void RemovingVehicles()
    {
        Vehicle[] vehicles = [
            new(VehicleTypes.Car, "EV0001", new ElectricEngine(408, 100.0m), 4, "White"),
            new(VehicleTypes.Motorcycle, "BIKE42", new FuelEngine(85, 0.6m, FuelTypes.Gasoline), 2, "Blue"),
            new(VehicleTypes.Bus, "TRK999", new FuelEngine(500, 12.7m, FuelTypes.Diesel), 18, "Orange"),
        ];
        Vehicle[] expected = [
            new(VehicleTypes.Car, "EV0001", new ElectricEngine(408, 100.0m), 4, "White"),
            new(VehicleTypes.Bus, "TRK999", new FuelEngine(500, 12.7m, FuelTypes.Diesel), 18, "Orange"),
        ];
        Garage garage = new(5);

        garage.BulkLoadVehicles(vehicles);
        garage.RemoveVehicle("BIKE42");
        var result = garage.GetAllVehicles();

        Assert.Equal(expected, result);
    }
}
