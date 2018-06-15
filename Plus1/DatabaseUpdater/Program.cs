using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Console = Colorful.Console;

namespace DatabaseUpdater
{
/*
------------------------------------------------------------
|                                                          |
|                   DatabaseUpdater                        |         
|                   Version: 1.5                           |
|                   By Tom                                 |
|                                                          |
------------------------------------------------------------
 */
    class Program
    {
        public string BaseURL = "http://supermaco.starwave.nl/api/";
        public string ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tom\Documents\GitHub\Plus1\Plus1\Plus1\App_Data\aspnet-Plus1-20180514115049.mdf;Initial Catalog=aspnet-Plus1-20180514115049;Integrated Security=True";
        static void Main(string[] args)
        {
            ShowOptions();
        }
        static void ShowOptions()
        {
            int DA = 244;
            int V = 212;
            int ID = 255;
            for (int i = 0; i < 1; i++)
            {
                Console.WriteAscii("DatabaseUpdater V1.5", Color.FromArgb(DA, V, ID));

                DA -= 18;
                V -= 36;
            }
            Console.WriteLine("What do you want to update?");
            string input = Console.ReadLine();

            ProductUpdater ProductUpdater = new ProductUpdater();
            CategoryUpdater CategoryUpdater = new CategoryUpdater();


            switch (input)
            {
                case "products":
                    ProductUpdater.Run();
                break; 
                case "categories":
                    CategoryUpdater.Run();
                break;
                case "promotions":
                break;
                case "all":
                    ProductUpdater.Run();
                    CategoryUpdater.Run();

                    break;
                case "help":
                    Console.WriteLine("- products");
                    Console.WriteLine("- categories");
                    Console.WriteLine("- all");
                    ShowOptions();     
                    break;
                default:
                    Console.WriteLine("Unknown Command: Use 'help' for all available commands.");
                    ShowOptions();
                break;
            }
        }


    }
}

