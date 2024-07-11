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
                        ShowActionTitle("Добавяне на нов паркинг");
                        AddNewParking();
                        break;
                    case "2":
                        ShowActionTitle("Нов идентификационен номер");
                        ParkingID();
                        break;
                    case "3":
                        ShowActionTitle("Регистрация на превозно средство");
                        AddCar();
                        break;
                    case "4":
                        ShowActionTitle("Напускане на паркинг");
                        RemoveCar();
                        break;
                    case "5":
                        ShowActionTitle("Проверка на наличността на паркоместата");
                        AvaliableSpots();
                        break;
                    case "6":
                        ShowActionTitle("Справка на всички паркинги");
                        AllParkings();
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

        private static void AllParkings()
        {
            foreach (var parking in parkings)
            {
                Console.WriteLine($"ID: {parking.ParkingID}, Местоположение: {parking.Location}, Всички паркоместа: {parking.TotalSpaces}, Свободни места: {parking.AvaliableSpaces}");
            }
            Console.ReadLine();
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
            Console.WriteLine("\t[2]: Нов идентификационен номер");
            Console.WriteLine("\t[3]: Регистрация на превозно средство");
            Console.WriteLine("\t[4]: Напускане на паркинг");
            Console.WriteLine("\t[5]: Проверка на наличността на паркоместата");
            Console.WriteLine("\t[6]: Справка на всички паркинги");
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

        private static void AvaliableSpots()
        {

            Console.Write("Въведете локация или Parking ID: ");
            string input = Console.ReadLine();
            var parking = parkings.FirstOrDefault(p => p.Location.Equals(input, StringComparison.OrdinalIgnoreCase) || p.ParkingID.ToString() == input);
            if (parking == null)
            {
                Console.WriteLine("Не е намерен паркинг.");
            }
            else
            {
                Console.WriteLine($"Свободни места в {parking.Location}: {parking.AvaliableSpaces}");
            }
            Console.ReadLine();
            
        }

        private static void RemoveCar()
        {
            Console.Write("Въведете Parking ID: ");
            int id = int.Parse(Console.ReadLine());
            var parking = parkings.FirstOrDefault(p => p.ParkingID == id);
            if (parking == null)
            {
                Console.WriteLine("Паркингът не е намерен.");
                Console.ReadLine();
                return;
            }
            Console.Write("Въведете регистрационния номер на превозното средство:");
            string vehicle = Console.ReadLine();
            if (parking.Vehicles.Remove(vehicle))
            {
                parking.AvailableSpaces++;
                SaveParkings();
                Console.WriteLine("Автомобила напусна паркинга успешно.");
            }
            else
            {
                Console.WriteLine("Превозното средство не е намерено.");
            }
            Console.ReadLine();
        }

        private static void AddCar()
        {
            Console.Write("Въведете Parking ID: ");
            int id = int.Parse(Console.ReadLine());
            var parking = parkings.FirstOrDefault(p => p.ParkingID == id);
            if (parking == null)
            {
                Console.WriteLine("Паркингът не е намерен.");
                Console.ReadLine();
                return;
            }
            if (parking.AvailableSpaces == 0)
            {
                Console.WriteLine("Няма свободни места.");
                Console.ReadLine();
                return;
            }
            Console.Write("Въведете регистрационния номер на превозното средство:");
            string vehicle = Console.ReadLine();
            parking.Vehicles.Add(vehicle);
            parking.AvailableSpaces--;
            SaveParkings();
            Console.WriteLine("Превозното средство е регистрирано успешно.");
            Console.ReadLine();
        }

        private static void ParkingID()
        {

            Console.Write("Въведете Parking ID: ");
            int id = int.Parse(Console.ReadLine());
            var parking = parkings.FirstOrDefault(p => p.ParkingID == id);

            if (parking == null)
            {
                Console.WriteLine("Не е намерен паркинг.");
                Console.ReadLine();
                return;
                
            }

            Console.Write("Въведете регистрационния номер на колата: ");
            string vehicle = Console.ReadLine();

            if (parking.Vehicles.Contains(vehicle))
            {
                Console.WriteLine("Този регистрационен номер вече е в паркинга.");
            }
            else
            {
                parking.Vehicles.Add(vehicle);
                parking.AvaliableSpaces--;
                SaveParkings();
                Console.WriteLine("Колата е регистрирана успешно.");
            }

            Console.ReadLine();
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

        public static void AddNewParking()
        {

            Console.Write("Въведете ID на новия паркинг: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Въведете местоположение на новия паркинг: ");
            string location = Console.ReadLine();

            Console.Write("Въведете общ брой паркоместа: ");
            int totalSpaces = int.Parse(Console.ReadLine());
            Console.WriteLine("Налични палкоместа");
            int avaliableSpaces = totalSpaces;
            Console.Write(avaliableSpaces);

            string o = " ";
            Parking newParking = new Parking(id.ToString(), location, totalSpaces, avaliableSpaces, o);
            parkings.Add(newParking);
            SaveParkings();

            Console.WriteLine("Новият паркинг е добавен успешно.");
            Console.ReadLine();
            
        }       
    }
}
