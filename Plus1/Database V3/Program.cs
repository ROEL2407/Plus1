using Database_V3.Updaters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Database_V3
{
    class Program
    {
        public static string BaseURL = "http://supermaco.starwave.nl/api/";

        static void Main(string[] args)
        {
            RunMenu();
        }
        static void RunMenu()
        {
            Console.WriteLine("What do you want to update?");
            string input = Console.ReadLine();

            switch (input)
            {
                case "products":
                    ProductUpdater.Run();
                    RunMenu();
                    break;
                case "categories":
                    CategoryUpdater.Run();
                    RunMenu();
                    break;
                case "promotions":
                    break;
                case "all":
                    ProductUpdater.Run();
                    CategoryUpdater.Run();
                    RunMenu();
                    break;
                case "help":
                    Console.WriteLine("- products");
                    Console.WriteLine("- categories");
                    Console.WriteLine("- all");
                    RunMenu();
                    break;
                default:
                    Console.WriteLine("Unknown Command: Use 'help' for all available commands.");
                    RunMenu();
                    break;
            }
        }


    }
}
