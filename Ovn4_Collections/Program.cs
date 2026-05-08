using Ovn4_Collections.Models.Data;
using Ovn4_Collections.Services;
using Spectre.Console;

namespace Ovn4_Collections;

class Program
{
    static void Main(string[] args)
    {
        string menuChoice;
        Garage garage = new(20);

        AnsiConsole.Write(new FigletText("Garage Management").Color(Color.CadetBlue));
        garage.BulkLoadVehicles(TestData.testVehicles);

        do {
            menuChoice = ConsoleMenu.DisplayMainMenu();

            switch (menuChoice)
            {
                case "list":
                    AnsiConsole.Write(new Text("All parked vehicles:\n"));
                    var vehicles = garage.GetAllVehicles();
                    ConsoleMenu.ListVehicles(vehicles);
                    break;
                case "park":
                    break;
                case "release":
                    garage.RemoveVehicle(ConsoleMenu.RemoveVehicle(garage.GetAllLicenceNumbers()));
                    break;
                default:
                    break;
            }
        } while (menuChoice != "quit");
    }
}
