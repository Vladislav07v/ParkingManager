using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        private const string filePath = "../../../parking.txt";

        private static List<Parking> flights = new List<Parking>();
        private static string menuActionChoice;
        static void Main(string[] args)
        {
            PrintMenu();
            while (true)
            {
                menuActionChoice = Console.ReadLine();
                switch (menuActionChoice)
                {
                    case "1":
                        ShowActionTitle("Създаване на нов паркинг");
                        ParkingID();
                        break;
                    case "2":
                        ParkingLocation();
                        break;
                    case "3":
                        TotalSpacest();
                        break;
                    case "4":
                        AvaliableSpaces();
                        break;
                    case "5":
                        Vehicles();
                        break;
                    case "x" or "X":
                        Exit();
                        break;
                    default:
                        // todo: implement default case
                        break;
                }
            }
        }

        private static void Exit()
        {
            throw new NotImplementedException();
        }

        private static void Vehicles()
        {
            throw new NotImplementedException();
        }

        private static void AvaliableSpaces()
        {
            throw new NotImplementedException();
        }

        private static void TotalSpacest()
        {
            throw new NotImplementedException();
        }

        private static void ParkingLocation()
        {
            throw new NotImplementedException();
        }

        private static void ParkingID()
        {
            throw new NotImplementedException();
        }

        private static void ShowActionTitle(string v)
        {
            throw new NotImplementedException();
        }
    }
}
