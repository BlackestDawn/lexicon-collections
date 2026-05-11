using Ovn4_Collections.Models;
using Ovn4_Collections.Models.Data;

namespace Ovn4_Collections.Services;

public class ManagementApp
{
    private readonly Garage _garage;
    private readonly IUIInterface _ui;

    public ManagementApp()
    {
        _garage = new Garage(20);
        _ui = new ConsoleUI(_garage.GetStatus);
    }

    public void RunApp()
    {
        MainMenuOptions menuChoice;
        _garage.BulkLoadVehicles(TestData.testVehicles);

        do {
            menuChoice = _ui.MainMenuWindow();

            try {
                switch (menuChoice)
                {
                    case MainMenuOptions.List:
                        var vehicle = _ui.VehicleListSelectionWindow(_garage.GetAllVehicles());
                        _ui.VehicleDetailsWindow(vehicle);
                        _ui.PauseDisplay();
                        _ui.ResetMenuPath();
                        break;
                    case MainMenuOptions.Add:
                        _garage.AddVehicle(_ui.AddVehicleWindow());
                        _ui.ResetMenuPath();
                        break;
                    case MainMenuOptions.Remove:
                        _garage.RemoveVehicle(_ui.RemoveVehicleWindow(_garage.GetAllLicenceNumbers()));
                        _ui.ResetMenuPath();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                _ui.ErrorMessage(ex.Message);
                _ui.ResetMenuPath();
            }
        } while (menuChoice != MainMenuOptions.Quit);
    }
}
