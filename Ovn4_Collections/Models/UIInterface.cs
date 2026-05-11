using Ovn4_Collections.Models.Vehicles;

namespace Ovn4_Collections.Models;

public interface IUIInterface
{
    public MainMenuOptions MainMenuWindow();
    public Vehicle VehicleListSelectionWindow(Vehicle[] vehicles);
    public string RemoveVehicleWindow(string[] licenceNumbers);
    public Vehicle AddVehicleWindow();
    public void PauseDisplay(string message = "Press any key to continue");
    public void ResetMenuPath();
    public void VehicleDetailsWindow(Vehicle vehicle);
    public void ErrorMessage(string message);
    public void WarningMessage(string message);
    public void SuccessMessage(string message);
    public Func<Vehicle, bool> SearchInputWindow();
    public void SearchResultWindow(Vehicle[] vehicles);
}
