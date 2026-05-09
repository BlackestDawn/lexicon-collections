using System.Reflection.Metadata.Ecma335;
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
        return new(
            this.AskForVehicleType(),
            this.AskForLicenceNumber(),
            this.AskForEngine(),
            this.AskForWheelCount(),
            this.AskForColor()
        );
    }

    private VehicleTypes AskForVehicleType()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<VehicleTypes>()
                .Title("Select vehicle type:")
                .AddChoices(Enum.GetValues<VehicleTypes>())
        );
    }

    private string AskForLicenceNumber()
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>("Enter licence number:")
                .Validate(input => input.Length >= 6, "Must be at least 6 characters")
            );
    }

    private IEngine AskForEngine()
    {
        var engineSelection = this.AskForEngineType();

        if (engineSelection == "Fuel based")
        {
            return new FuelEngine(
                this.AskForEngineHP(),
                this.AskForEngineDisplacementVolume(),
                this.AskForEngineFuelType()
            );
        }
        else
        {
            return new ElectricEngine(
                this.AskForEngineHP(),
                this.AskForEngineBatteryCapacity()
            );
        }
    }

    private string AskForEngineType()
    {
        return AnsiConsole.Prompt<string>(
            new SelectionPrompt<string>()
                .Title("Select engine type")
                .AddChoices("Fuel based", "Electric")
            );
    }

    private int AskForEngineHP()
    {
        return AnsiConsole.Prompt(
            new TextPrompt<int>("Enter horse power of engine:")
                .Validate(input => input > 0, "Must be a positive number")
            );
    }

    private FuelTypes AskForEngineFuelType()
    {
        return AnsiConsole.Prompt(
                new SelectionPrompt<FuelTypes>()
                    .Title("Select engine's fuel type:")
                    .AddChoices(Enum.GetValues<FuelTypes>())
            );
    }

    private decimal AskForEngineDisplacementVolume()
    {
        return AnsiConsole.Prompt(
                new TextPrompt<decimal>("Enter engine's displacement volume in liters:")
                    .Validate(input => input > 0, "Must be a positive number")
            );
    }

    private decimal AskForEngineBatteryCapacity()
    {
        return AnsiConsole.Prompt(
                new TextPrompt<decimal>("Enter engine's battery capacity in kWh:")
                    .Validate(input => input > 0, "Must be a positive number")
            );
    }

    private int AskForWheelCount()
    {
        return AnsiConsole.Prompt(
            new TextPrompt<int>("Enter number of wheels:")
                .Validate(input => input >= 0, "Cannot be a negative number")
        );
    }

    private string AskForColor()
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>("Enter vehicle's color:")
        );
    }
}
