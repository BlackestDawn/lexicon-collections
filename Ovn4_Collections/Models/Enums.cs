using System.ComponentModel;

namespace Ovn4_Collections.Models;

public enum VehicleTypes
{
    Car,
    Bus,
    Motorcycle,
    Boat,
    Airplane
}

public enum MainMenuOptions
{
    [Description("View vehicles")]      List,
    [Description("Park a vehicle")]     Add,
    [Description("Release a vehicle")]  Remove,
    [Description("Quit")]               Quit,
}

public enum CarTypes
{
    SUV,
    Sedan,
    Hatchback,
    [Description("Pickup Truck")]
    Pickup,
    [Description("Minivan / MPV")]
    Minivan,
    Coupe,
    Convertible,
    [Description("Station Wagon")]
    Station,
    [Description("Sports Car")]
    Sport,
}
