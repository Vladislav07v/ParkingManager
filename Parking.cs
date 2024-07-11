using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagementSystrem
{
    internal class Parking
    {
        private int totalSpaces;
        private int avaliableSpaces;
        public string ParkingID { get; private set; }
        public string Location { get; private set; }
        public int TotalSpaces
        {
            get { return totalSpaces; }
            private set
            {
                if (value <= 0) { throw new ArgumentException("Броят на всички парко места трябва да е положителен!"); }
                totalSpaces = value;
            }
        }
        public int AvaliableSpaces
        {
            get { return avaliableSpaces; }
            set
            {
                if (value < 0) { throw new ArgumentException("Броят на наличните парко места трябва да е положителен!"); }
                avaliableSpaces = value;
            }
        }
        public List<string> Vehicles { get; private set; }

        public Parking(string parkingId, string location, int totalSpaces, int avaliableSpaces, List<string> vehicles)
        {
            ParkingID = parkingId;
            Location = location;
            TotalSpaces = totalSpaces;
            AvaliableSpaces = avaliableSpaces;
            Vehicles = vehicles;
        }
        public override string ToString()
        {
            string vehiclesToString = string.Join(':', Vehicles);
            return $"{ParkingID},{Location},{TotalSpaces},{AvaliableSpaces},{vehiclesToString}";
        }
        public void DecreaseSeats(int ticketsCount)
        {
            if (AvaliableSpaces < TotalSpaces)
            {
                Console.WriteLine("Няма толкова налични места.");
                return;
            }
            AvaliableSpaces -= TotalSpaces;
            Console.WriteLine("Опитайте пак.");
        }
    }
}
