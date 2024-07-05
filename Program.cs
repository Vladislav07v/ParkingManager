using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
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
                        ParkingLocation();
                        break;
                    case "3":
                        TotalSpaces();
                        break;
                    case "4":
                        AvaliableSpaces();
                        break;
                    case "5":
                        Vehicles();
                        break;
                    case "x" || "X":
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

        private static void TotalSpaces()
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
                    string[] flightInfo = line.Split(',').ToArray();
                    string flightId = flightInfo[0];
                    string destination = flightInfo[1];
                    DateTime departureTime = Convert.ToDateTime(flightInfo[2]);
                    DateTime arrivalTime = Convert.ToDateTime(flightInfo[3]);
                    int seatsAvailable = int.Parse(flightInfo[4]);
                    decimal price = decimal.Parse(flightInfo[5]);

                    Parking currentFlight = new Parking(parkingId, location, totalSpaces, avaliableSpaces, vehicles);
                    parkings.Add(currentParking);
                }
            }
        }
    }
}
