using Ovn4_Collections.Models.Vehicles;
using Spectre.Console;

namespace Ovn4_Collections.Services;

public static class ConsoleMenu
{
    public static string DisplayMainMenu()
    {
        string val = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Main menu")
                .AddChoices(
                    "List parked vehicles",
                    "Park a vehicle",
                    "Release a vehicle",
                    "Quit"
                )
        );
        return val.Split(" ")[0].ToLower();
    }

    public static void ListVehicles(Vehicle[] vehicles)
    {
        foreach (var vehicle in vehicles)
        {
            AnsiConsole.Write(new Text($"{vehicle}"));
        }
    }

    public static string RemoveVehicle(string[] licenceNumbers)
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select vehicle to release:")
            .AddChoices(licenceNumbers)
        );
    }
}
