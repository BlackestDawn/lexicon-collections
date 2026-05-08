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
}
