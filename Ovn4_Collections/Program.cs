using Ovn4_Collections.Models;
using Ovn4_Collections.Models.Data;
using Ovn4_Collections.Services;

namespace Ovn4_Collections;

class Program
{
    static void Main(string[] args)
    {
        Garage garage = new(20);
        IUIInterface ui = new ConsoleUI();

        ManagementApp app = new(garage, ui);
        app.RunApp();
    }
}
