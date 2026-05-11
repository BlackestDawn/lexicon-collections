using System.Collections;
using System.Text;
using Ovn4_Collections.Extensions;
using Ovn4_Collections.Helpers;
using Ovn4_Collections.Models;
using Ovn4_Collections.Models.Vehicles;
using Spectre.Console;

namespace Ovn4_Collections.Services;

public class ConsoleUI: IUIInterface
{
    private readonly Func<Hashtable> _usageStatus;
    private Stack _menuPath = new Stack(5);
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
        this._menuPath.Push("Main Menu");
    }

    private void RenderHeader()
    {
        StringBuilder menuPathSB = new StringBuilder();
        int depthCounter = this._menuPath.Count;
        foreach (string item in this._menuPath)
        {
            menuPathSB.PrependLine($"{new String(' ', 2 * depthCounter)}{item}");
            depthCounter--;
        }

        Panel menuPathPanel = new Panel(menuPathSB.ToString())
            .Header("  Menu path")
            .Expand()
            .NoBorder()
            .Padding(0, 2);

        Hashtable currentStatus = this._usageStatus();

        Panel usagePanel = new Panel(
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
                Align.Left(menuPathPanel),
                Align.Center(usagePanel),
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

    public void PauseDisplay(string message = "Press any key to continue")
    {
        AnsiConsole.MarkupLine($"\n[gray]{message}[/]");
        Console.ReadKey(intercept: true);
    }

    public void ResetMenuPath()
    {
        this._menuPath.Clear();
        this._menuPath.Push("Main Menu");
    }

    public MainMenuOptions MainMenuWindow()
    {
        this.RenderHeader();
        return AnsiConsole.Prompt(
            new SelectionPrompt<MainMenuOptions>()
                .UseConverter(EnumHelpers.GetDescription)
                .AddChoices(Enum.GetValues<MainMenuOptions>())
        );
    }

    public void VehicleListWindow(Vehicle[] vehicles)
    {
        this._menuPath.Push("Vehicle list");
        this.RenderHeader();
        AnsiConsole.Write(new Text("All parked vehicles:\n"));
        foreach (var vehicle in vehicles)
        {
            AnsiConsole.Write(new Text($"{vehicle.FullDescription()}"));
        }
        AnsiConsole.WriteLine();
        this._menuPath.Pop();
    }

    public string RemoveVehicleWindow(string[] licenceNumbers)
    {
        this._menuPath.Push("Releasing vehicle");
        this.RenderHeader();
        string licenceNumber = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select vehicle to release:")
                .AddChoices(licenceNumbers)
        );
        this._menuPath.Pop();
        return licenceNumber;
    }

    public Vehicle AddVehicleWindow()
    {
        this._menuPath.Push("Adding vehicle");
        this.RenderHeader();
        Vehicle newVehicle = new(
            this.AskForVehicleType(),
            this.AskForLicenceNumber(),
            this.AskForEngine(),
            this.AskForWheelCount(),
            this.AskForColor()
        );
        this._menuPath.Pop();
        return newVehicle;
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
