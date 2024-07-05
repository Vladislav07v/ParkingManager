using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Parking
    {
        private int totalSpaces;
        private int avaliableSpaces;
        public string ParkingID {  get; private set; }
        public string Location { get; private set; }
        public int TotalSpaces
        {
            get { return totalSpaces; }
            private set
            {
                if (value <= 0) { throw new ArgumentException("Броят на всички парко места трябва да е положителен!"); }
            }
        }
        public int AvaliableSpaces 
        {
            get { return avaliableSpaces; }
            private set
            {
                if (value <= 0) { throw new ArgumentException("Броят на наличните парко места трябва да е положителен!"); }
            }
        }
        public string Vehicles { get; private set; }

        public Parking(string parkingId, string location, int totalSpaces, int avaliableSpaces, string vehicles)
        {
            ParkingID = parkingId;
            Location = location;
            TotalSpaces = totalSpaces;
            AvaliableSpaces = avaliableSpaces;
            Vehicles = vehicles;
        }
    }
}
