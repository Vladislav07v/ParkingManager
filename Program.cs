using ParkingManagementSystrem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagementSystrem
{
    internal class Program
    {
        private const string filePath = "../../../parking.txt";

        private static List<Parking> parkings = new List<Parking>();
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
                        ShowActionTitle("Местоположение на паркинга");
                        ParkingLocation();
                        break;
                    case "3":
                        ShowActionTitle("Брой паркоместа");
                        TotalSpaces();
                        break;
                    case "4":
                        ShowActionTitle("Налични паркоместа");
                        AvaliableSpaces();
                        break;
                    case "5":
                        ShowActionTitle("Регистрационен номер на колата");
                        Vehicles();
                        break;
                    case "x" or "X":
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Това на е налична опция");
                        break;
                }
            }
        }

        private static void PrintMenu()
        {
            throw new NotImplementedException();
            //За Митко
        }

        private static void ShowActionTitle(string title)
        {
            Console.Clear();
            AddLine();
            Console.WriteLine("\t" + title);
            AddLine();
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }

        private static void Vehicles()
        {
            throw new NotImplementedException();
            //За Джан
        }

        private static void AvaliableSpaces()
        {
            throw new NotImplementedException();
            //За Джан
        }

        private static void TotalSpaces()
        {
            throw new NotImplementedException();
            //За Джан
        }

        private static void ParkingLocation()
        {
            throw new NotImplementedException();
            //За Джан
        }

        private static void ParkingID()
        {
            throw new NotImplementedException();
            //За Джан
        }

        private static void SaveParkings()
        {
            StreamWriter writer = new StreamWriter(filePath, false, Encoding.Unicode);
            using (writer)
            {
                foreach (Parking parking in parkings)
                {
                    writer.WriteLine(parking);
                }
            }
        }

        private static void LoadParkings()
        {
            StreamReader reader = new StreamReader(filePath, Encoding.Unicode);
            using (reader)
            {
                string line;
                while ((line = Console.ReadLine()) != null)
                {
                    string[] parkingInfo = line.Split(',').ToArray();
                    string parkingId = parkingInfo[0];
                    string location = parkingInfo[1];
                    int totalSpaces = int.Parse(parkingInfo[2]);
                    int avaliableSpaces = int.Parse(parkingInfo[3]);
                    string vehicles = parkingInfo[4];

                    Parking currentParking = new Parking(parkingId, location, totalSpaces, avaliableSpaces, vehicles);
                    parkings.Add(currentParking);
                }
            }
        }
        
        private static void ListParkings()
        {
            foreach (Parking parking in parkings)
            {
                PrintParkingInfo(parking);
                AddLine();
            }

            BackToMenu();
        }

        private static void BackToMenu()
        {
            throw new NotImplementedException();
            //За Митко
        }

        private static void AddLine()
        {
            throw new NotImplementedException();
            //За Митко
        }

        private static void PrintParkingInfo(Parking parking)
        {
            throw new NotImplementedException();
            //За Митко
        }

        private static void ShowResultMessage(string message)
        {
            AddLine();
            Console.WriteLine("\t" + message);
        }

        private static void AddNewParking()
        {
            throw new NotImplementedException();
            //За Джан
        }

        private static void SearchParking()
        {
            throw new NotImplementedException();
            //За Джан
        }
    }
}
