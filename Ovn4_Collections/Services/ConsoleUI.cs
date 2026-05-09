using Ovn4_Collections.Helpers;
using Ovn4_Collections.Models;
using Ovn4_Collections.Models.Vehicles;
using Spectre.Console;

namespace Ovn4_Collections.Services;

public class ConsoleUI: IUIInterface
{
    public ConsoleUI()
    {
        AnsiConsole.Write(new FigletText("Garage Management").Color(Color.CadetBlue));
    }
    public MainMenuOptions MainMenuWindow()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<MainMenuOptions>()
                .Title("Main menu")
                .UseConverter(EnumHelpers.GetDescription)
                .AddChoices(Enum.GetValues<MainMenuOptions>())
        );
    }

    public void VehicleListWindow(Vehicle[] vehicles)
    {
        AnsiConsole.Write(new Text("All parked vehicles:\n"));
        foreach (var vehicle in vehicles)
        {
            AnsiConsole.Write(new Text($"{vehicle}"));
        }
        AnsiConsole.WriteLine();
    }

    public string RemoveVehicleWindow(string[] licenceNumbers)
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select vehicle to release:")
                .AddChoices(licenceNumbers)
        );
    }

    public Vehicle AddVehicleWindow()
    {
        var vehicleType = AnsiConsole.Prompt(
            new SelectionPrompt<VehicleTypes>()
                .Title("Select vehicle type:")
                .AddChoices(Enum.GetValues<VehicleTypes>())
        );

        var licenceNumber = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter licence number:")
                .Validate(input => input.Length >= 6, "Must be at least 6 characters")
            );

        var engineSelection = AnsiConsole.Prompt<string>(
            new SelectionPrompt<string>()
                .Title("Select engine type")
                .AddChoices("Fuel based", "Electric")
        );

        IEngine engineType;
        var engineHP = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter horse power of engine:")
                .Validate(input => input > 0, "Must be a positive number")
            );
        if (engineSelection == "Fuel based")
        {
            var displacementLiters = AnsiConsole.Prompt(
                new TextPrompt<decimal>("Enter engine's displacement volume in liters:")
                    .Validate(input => input > 0, "Must be a positive number")
            );
            var fuel = AnsiConsole.Prompt(
                new SelectionPrompt<FuelTypes>()
                    .Title("Select engine's fuel type:")
                    .AddChoices(Enum.GetValues<FuelTypes>())
            );
            engineType = new FuelEngine(engineHP, displacementLiters, fuel);
        }
        else
        {
            var capacity = AnsiConsole.Prompt(
                new TextPrompt<decimal>("Enter engine's battery capacity in kWh:")
                    .Validate(input => input > 0, "Must be a positive number")
            );
            engineType = new ElectricEngine(engineHP, capacity);
        }

        var wheelAmount = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter number of wheels:")
                .Validate(input => input >= 0, "Cannot be a negative number")
        );

        var color = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter vehicle's color:")
        );

        return new(
            vehicleType,
            licenceNumber,
            engineType,
            wheelAmount,
            color
        );
    }
}
