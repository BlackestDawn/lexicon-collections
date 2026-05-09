using Ovn4_Collections.Models;
using Ovn4_Collections.Models.Data;
using Ovn4_Collections.Services;

namespace Ovn4_Collections;

class Program
{
    static void Main(string[] args)
    {
        string menuChoice;
        Garage garage = new(20);
        IUIInterface ui = new ConsoleUI();

        garage.BulkLoadVehicles(TestData.testVehicles);


        do {
            menuChoice = ui.MainMenuWindow();

            switch (menuChoice)
            {
                case "list":
                    ui.VehicleListWindow(garage.GetAllVehicles());
                    break;
                case "park":
                    garage.AddVehicle(ui.AddVehicleWindow());
                    break;
                case "release":
                    garage.RemoveVehicle(ui.RemoveVehicleWindow(garage.GetAllLicenceNumbers()));
                    break;
                default:
                    break;
            }
        } while (menuChoice != "quit");
    }
}
