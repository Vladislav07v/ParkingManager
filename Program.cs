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
            Console.Clear();

            AddLine();
            Console.WriteLine("\tМ Е Н Ю");
            AddLine();
            Console.WriteLine("\tИзберете желаното действие:");
            AddLine();
            Console.WriteLine("\t[1]: Добавяне на нов паркинг");
            Console.WriteLine("\t[2]: Регистрация на ново п.с.");
            Console.WriteLine("\t[3]: Напускане на паркинг от п. с.");
            Console.WriteLine("\t[4]: Налични паркоместа");
            Console.WriteLine("\t[x]: Изход от програмата");
            AddLine();
            Console.Write("\tВашият избор: ");
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
            AddLine();
            Console.Write("\tОбратно към менюто: ");
            Console.ReadLine();
            PrintMenu();
        }

        private static void AddLine(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(Environment.NewLine);
            }
        }

        private static void PrintParkingInfo(Parking parking)
        {
            Console.WriteLine($"\tНомер на полета: {parking.ParkingID}");
            Console.WriteLine($"\tДо: {parking.Location}");
            Console.WriteLine($"\tИзлитане: {parking.TotalSpaces.ToString()}");
            Console.WriteLine($"\tКацане: {parking.AvaliableSpaces.ToString()}");
            Console.WriteLine($"\tСвободни места: {parking.Vehicles}");
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
