using Ovn4_Collections.Models;
using Ovn4_Collections.Models.Vehicles;
using Ovn4_Collections.Services;
using Spectre.Console;

namespace Ovn4_Collections;

class Program
{
    static void Main(string[] args)
    {
        string menuChoice;
        AnsiConsole.Write(new FigletText("Garage Management").Color(Color.CadetBlue));

        do {
            menuChoice = ConsoleMenu.DisplayMainMenu();

            Console.WriteLine($"Menu choice: {menuChoice}");
        } while (menuChoice != "quit");
    }
}

public static class TestData
{
    public static Vehicle[] testVehicles =
    [
        new("ABC123", new FuelEnginesStats(150, 2.0m, FuelTypes.Gasoline), 4, "Red"),
        new("XYZ789", new FuelEnginesStats(320, 3.0m, FuelTypes.Diesel), 4, "Black"),
        new("EV0001", new ElectricEnginesStats(408, 100.0m), 4, "White"),
        new("BIKE42", new FuelEnginesStats(85, 0.6m, FuelTypes.Gasoline), 2, "Blue"),
        new("TRK999", new FuelEnginesStats(500, 12.7m, FuelTypes.Diesel), 18, "Orange"),
        new("EV0042", new ElectricEnginesStats(670, 200.0m), 18, "Silver"),
        new("AIR001", new FuelEnginesStats(260, 5.2m, FuelTypes.Avgas), 3, "Yellow"),
        new("JET007", new FuelEnginesStats(90000, 0.0m, FuelTypes.JetAA1), 3, "White"),
        new("BIO555", new FuelEnginesStats(110, 1.6m, FuelTypes.Biofuel), 4, "Green"),
        new("EV0099", new ElectricEnginesStats(204, 58.0m), 4, "Gray"),
    ];
}
