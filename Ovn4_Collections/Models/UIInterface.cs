using Ovn4_Collections.Models.Vehicles;

namespace Ovn4_Collections.Models;

public interface IUIInterface
{
    public MainMenuOptions MainMenuWindow();
    public void VehicleListWindow(Vehicle[] vehicles);
    public string RemoveVehicleWindow(string[] licenceNumbers);
    public Vehicle AddVehicleWindow();
    public void PauseDisplay(string message = "Press any key to continue");
}
