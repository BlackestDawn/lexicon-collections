using Ovn4_Collections.Models;
using Ovn4_Collections.Models.Data;
using Ovn4_Collections.Models.Vehicles;

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
                        Vehicle[] vehicles = _garage.GetAllVehicles();
                        if (vehicles.Length > 0)
                        {
                            _ui.VehicleDetailsWindow(_ui.VehicleListSelectionWindow(vehicles));
                        }
                        else
                        {
                            _ui.WarningMessage("Nothing to view, no vehicles parked.");
                        }
                        _ui.PauseDisplay();
                        _ui.ResetMenuPath();
                        break;
                    case MainMenuOptions.Add:
                        if (_garage.UsedSpace < _garage.MaxSpace)
                        {
                            Vehicle vehicle = _ui.AddVehicleWindow();
                            _garage.AddVehicle(vehicle);
                            _ui.SuccessMessage($"Vehicle '{vehicle.MinimalDescription}' added.");
                        }
                        else
                        {
                            _ui.WarningMessage("Can't add vehicle, no more space left.");
                        }
                        _ui.ResetMenuPath();
                        break;
                    case MainMenuOptions.Remove:
                        string[] licenses = _garage.GetAllLicenceNumbers();
                        if (licenses.Length > 0)
                        {
                            string licence = _ui.RemoveVehicleWindow(licenses);
                            _garage.RemoveVehicle(licence);
                            _ui.SuccessMessage($"Vechile with licence number '{licence}' removed.");
                        }
                        else
                        {
                            _ui.WarningMessage("Nothing to remove, no vehicles parked.");
                        }
                        _ui.ResetMenuPath();
                        break;
                    default:
                        _ui.ErrorMessage($"Menu option does not exist or is not implemented yet: {menuChoice}");
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
