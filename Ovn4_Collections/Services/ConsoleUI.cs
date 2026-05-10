using System.Collections;
using Ovn4_Collections.Helpers;
using Ovn4_Collections.Models;
using Ovn4_Collections.Models.Vehicles;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Ovn4_Collections.Services;

public class ConsoleUI: IUIInterface
{
    private readonly Func<Hashtable> _usageStatus;
    private readonly Color[] _typesColor = new Color[]
    {
        Color.Magenta,
        Color.LightGreen,
        Color.Cyan,
        Color.DarkBlue,
        Color.LightPink4
    };

    public ConsoleUI(Func<Hashtable> getStatus)
    {
        this._usageStatus = getStatus;
    }

    private void RenderHeader(IRenderable? content)
    {
        Hashtable currentStatus = this._usageStatus();

        Panel totalUsage = new Panel(
            new BreakdownChart()
                .Width(20)
                .AddItem("Used:", (int)currentStatus["used"], Color.Red3)
                .AddItem("Free:", (int)currentStatus["total"] - (int)currentStatus["used"], Color.LightYellow3)
            )
            .Header("Space usage")
            .NoBorder()
            .Padding(2, 1);

        BreakdownChartItem[] typesBreakdown = new BreakdownChartItem[Enum.GetNames<VehicleTypes>().Length];

        foreach (DictionaryEntry item in (Hashtable)currentStatus["types"])
        {
            typesBreakdown[(int)item.Key] = new BreakdownChartItem($"{item.Key}", (int)item.Value, this._typesColor[(int)item.Key]);
        }

        Panel typesPanel = new Panel(
            new BreakdownChart()
                .Width(30)
                .AddItems(typesBreakdown)
            )
            .Header("Usage by types")
            .NoBorder()
            .Padding(2, 1);

        Grid mainGrid = new Grid()
            .AddColumns(3)
            .AddRow(
                content ?? new Text(""),
                Align.Center(totalUsage),
                Align.Right(typesPanel)
            );

        Panel mainPanel = new Panel(mainGrid)
            .Header("[yellow]===[/] [cadetBlue]Garage Management[/] [yellow]===[/]", Justify.Center)
            .RoundedBorder()
            .BorderColor(Color.Yellow)
            .Padding(4, 2)
            .Expand();

        AnsiConsole.Clear();
        AnsiConsole.Write(mainPanel);
    }

    public MainMenuOptions MainMenuWindow()
    {
        this.RenderHeader(new Text("Main Menu"));
        return AnsiConsole.Prompt(
            new SelectionPrompt<MainMenuOptions>()
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
