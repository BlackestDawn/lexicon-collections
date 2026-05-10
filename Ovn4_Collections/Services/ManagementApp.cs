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
        this._ui = new ConsoleUI();
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
                    break;
                case MainMenuOptions.Add:
                    this._garage.AddVehicle(this._ui.AddVehicleWindow());
                    break;
                case MainMenuOptions.Remove:
                    this._garage.RemoveVehicle(this._ui.RemoveVehicleWindow(this._garage.GetAllLicenceNumbers()));
                    break;
                default:
                    break;
            }
        } while (menuChoice != MainMenuOptions.Quit);
    }
}
