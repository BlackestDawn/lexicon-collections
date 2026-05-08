using Ovn4_Collections.Models.Vehicles;

namespace Ovn4_Collections.Models.Data;

public static class TestData
{
    public static Vehicle[] testVehicles =
    [
        new(VehicleTypes.Car,        "ABC123", new FuelEnginesStats(150, 2.0m, FuelTypes.Gasoline),   4,  "Red"),
        new(VehicleTypes.Car,        "XYZ789", new FuelEnginesStats(320, 3.0m, FuelTypes.Diesel),     4,  "Black"),
        new(VehicleTypes.Car,        "EV0001", new ElectricEnginesStats(408, 100.0m),                 4,  "White"),
        new(VehicleTypes.Motorcycle, "BIKE42", new FuelEnginesStats(85, 0.6m, FuelTypes.Gasoline),    2,  "Blue"),
        new(VehicleTypes.Bus,        "TRK999", new FuelEnginesStats(500, 12.7m, FuelTypes.Diesel),    18, "Orange"),
        new(VehicleTypes.Bus,        "EV0042", new ElectricEnginesStats(670, 200.0m),                 18, "Silver"),
        new(VehicleTypes.Airplane,   "AIR001", new FuelEnginesStats(260, 5.2m, FuelTypes.Avgas),      3,  "Yellow"),
        new(VehicleTypes.Airplane,   "JET007", new FuelEnginesStats(90000, 0.0m, FuelTypes.JetAA1),   3,  "White"),
        new(VehicleTypes.Car,        "BIO555", new FuelEnginesStats(110, 1.6m, FuelTypes.Biofuel),    4,  "Green"),
        new(VehicleTypes.Boat,       "EV0099", new ElectricEnginesStats(204, 58.0m),                  0,  "Gray"),
    ];
}
