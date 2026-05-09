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
            menuChoice = ConsoleUI.DisplayMainMenu();

            switch (menuChoice)
            {
                case "list":
                    ConsoleUI.ListVehicles(garage.GetAllVehicles());
                    break;
                case "park":
                    garage.AddVehicle(ConsoleUI.AddVehicle());
                    break;
                case "release":
                    garage.RemoveVehicle(ConsoleUI.RemoveVehicle(garage.GetAllLicenceNumbers()));
                    break;
                default:
                    break;
            }
        } while (menuChoice != "quit");
    }
}
