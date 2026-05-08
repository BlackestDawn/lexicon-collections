using Ovn4_Collections.Services;
using Spectre.Console;

namespace Ovn4_Collections;

class Program
{
    static void Main(string[] args)
    {
        string menuChoice;
        AnsiConsole.Write(new FigletText("Garage Management").Color(Color.CadetBlue));

        do {
            menuChoice = ConsoleMenu.DisplayMainMenu();

            Console.WriteLine($"Menu choice: {menuChoice}");
        } while (menuChoice != "quit");
    }
}
