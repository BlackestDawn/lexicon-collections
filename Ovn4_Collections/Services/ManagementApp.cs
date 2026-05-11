using Ovn4_Collections.Models;
using Ovn4_Collections.Models.Data;

namespace Ovn4_Collections.Services;

public class ManagementApp
{
    private readonly Garage _garage;
    private readonly IUIInterface _ui;

    public ManagementApp()
    {
        this._garage = new Garage(20);
        this._ui = new ConsoleUI(this._garage.GetStatus);
    }

    public void RunApp()
    {
        MainMenuOptions menuChoice;
        this._garage.BulkLoadVehicles(TestData.testVehicles);

        do {
            menuChoice = this._ui.MainMenuWindow();

            switch (menuChoice)
            {
                case MainMenuOptions.List:
                    this._ui.VehicleListWindow(this._garage.GetAllVehicles());
                    this._ui.PauseDisplay();
                    this._ui.ResetMenuPath();
                    break;
                case MainMenuOptions.Add:
                    this._garage.AddVehicle(this._ui.AddVehicleWindow());
                    this._ui.ResetMenuPath();
                    break;
                case MainMenuOptions.Remove:
                    this._garage.RemoveVehicle(this._ui.RemoveVehicleWindow(this._garage.GetAllLicenceNumbers()));
                    this._ui.ResetMenuPath();
                    break;
                default:
                    break;
            }
        } while (menuChoice != MainMenuOptions.Quit);
    }
}
